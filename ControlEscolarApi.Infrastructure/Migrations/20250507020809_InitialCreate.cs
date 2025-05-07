using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControlEscolarApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alumnos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ApellidoPaterno = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ApellidoMaterno = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumeroControl = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Estatus = table.Column<bool>(type: "bit", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alumnos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposPersonal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Prefijo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SueldoMinimo = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    SueldoMaximo = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposPersonal", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Personal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ApellidoPaterno = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ApellidoMaterno = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumeroControl = table.Column<string>(type: "nvarchar(26)", maxLength: 26, nullable: false),
                    Sueldo = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Estatus = table.Column<bool>(type: "bit", nullable: false),
                    TipoPersonalId = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Personal_TiposPersonal_TipoPersonalId",
                        column: x => x.TipoPersonalId,
                        principalTable: "TiposPersonal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alumnos_Correo",
                table: "Alumnos",
                column: "Correo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Alumnos_NumeroControl",
                table: "Alumnos",
                column: "NumeroControl",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Personal_Correo",
                table: "Personal",
                column: "Correo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Personal_NumeroControl",
                table: "Personal",
                column: "NumeroControl",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Personal_TipoPersonalId",
                table: "Personal",
                column: "TipoPersonalId");

            migrationBuilder.CreateIndex(
                name: "IX_TiposPersonal_Prefijo",
                table: "TiposPersonal",
                column: "Prefijo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.Sql(@"
            CREATE OR ALTER PROCEDURE sp_ActualizarNumerosControl
                @TipoPersonalId INT,
                @NuevoPrefijo NVARCHAR(10)
            AS
            BEGIN
                SET NOCOUNT ON;
    
                BEGIN TRY
                    BEGIN TRANSACTION;
                    
                    -- 1. Validar que el nuevo prefijo no cause duplicados
                    IF EXISTS (
                        SELECT 1 
                        FROM Personal p1
                        JOIN Personal p2 ON 
                            p2.Id <> p1.Id AND
                            concat(@NuevoPrefijo, SUBSTRING(p2.NumeroControl, CHARINDEX('-', p2.NumeroControl), LEN(p2.NumeroControl))) = p1.NumeroControl
                    )
                    BEGIN
                        RAISERROR('El cambio de prefijo causaría duplicados en números de control', 16, 1);
                        ROLLBACK;
                        RETURN;
                    END;
                    
                    UPDATE p
                    SET NumeroControl = concat(@NuevoPrefijo,  SUBSTRING(p.NumeroControl, CHARINDEX('-', p.NumeroControl), LEN(p.NumeroControl)))
                    FROM Personal p
                    WHERE p.TipoPersonalId = @TipoPersonalId;
                    
                    COMMIT;
                END TRY
                BEGIN CATCH
                    IF @@TRANCOUNT > 0
                        ROLLBACK;
                        
                    THROW;
                END CATCH;
            END;");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alumnos");

            migrationBuilder.DropTable(
                name: "Personal");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "TiposPersonal");

            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS sp_ActualizarNumerosControl");
        }
    }
}
