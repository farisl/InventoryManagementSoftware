using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InventoryManagementSoftware.Migrations
{
    public partial class DataUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Exports",
                columns: new[] { "Id", "CustomerId", "Date", "EmployeeId", "InventoryId" },
                values: new object[] { 1, 1, new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 });

            migrationBuilder.InsertData(
                table: "Imports",
                columns: new[] { "Id", "Date", "EmployeeId", "InventoryId", "SupplierId" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 2 },
                    { 2, new DateTime(2021, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 1 }
                });

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Helena - MT");

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Jacksonville - FL");

            migrationBuilder.InsertData(
                table: "ExportDetails",
                columns: new[] { "Id", "Discount", "ExportId", "Price", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { 1, 0.20000000000000001, 1, 235.80000000000001, 3, 5.0 },
                    { 2, 0.0, 1, 54.990000000000002, 5, 1.0 },
                    { 3, 0.40000000000000002, 1, 77.989999999999995, 6, 1.0 }
                });

            migrationBuilder.InsertData(
                table: "ImportDetails",
                columns: new[] { "Id", "Discount", "ImportId", "Price", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { 1, 0.29999999999999999, 1, 288.86000000000001, 3, 7.0 },
                    { 2, 0.0, 1, 400.0, 4, 5.0 },
                    { 3, 0.0, 1, 90.0, 8, 6.0 },
                    { 4, 0.5, 2, 44.0, 1, 2.0 },
                    { 5, 0.0, 2, 15.0, 2, 3.0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ExportDetails",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ExportDetails",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ExportDetails",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ImportDetails",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ImportDetails",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ImportDetails",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ImportDetails",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ImportDetails",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Exports",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Imports",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Imports",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: null);

            migrationBuilder.UpdateData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: null);
        }
    }
}
