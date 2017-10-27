using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tiffanys.Migrations
{
    public partial class SeedDatabaseItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.Sql("INSERT INTO products (Name, Cost, RetailPrice) VALUES ('Bracelet', 64.25, 89.99)");
			migrationBuilder.Sql("INSERT INTO products (Name, Cost, RetailPrice) VALUES ('Necklace', 88.50, 129.99)");
			migrationBuilder.Sql("INSERT INTO products (Name, Cost, RetailPrice) VALUES ('Ring', 137.25, 179.99)");
			migrationBuilder.Sql("INSERT INTO products (Name, Cost, RetailPrice) VALUES ('Earring', 71.50, 99.99)");

			migrationBuilder.Sql("INSERT INTO items (Sold, ProductId) VALUES (false, (SELECT ProductId FROM products WHERE Name = 'Bracelet'))");
			migrationBuilder.Sql("INSERT INTO items (Sold, ProductId) VALUES (false, (SELECT ProductId FROM products WHERE Name = 'Bracelet'))");
			migrationBuilder.Sql("INSERT INTO items (Sold, ProductId) VALUES (false, (SELECT ProductId FROM products WHERE Name = 'Bracelet'))");
			migrationBuilder.Sql("INSERT INTO items (Sold, ProductId) VALUES (false, (SELECT ProductId FROM products WHERE Name = 'Necklace'))");
			migrationBuilder.Sql("INSERT INTO items (Sold, ProductId) VALUES (false, (SELECT ProductId FROM products WHERE Name = 'Necklace'))");
			migrationBuilder.Sql("INSERT INTO items (Sold, ProductId) VALUES (false, (SELECT ProductId FROM products WHERE Name = 'Necklace'))");
			migrationBuilder.Sql("INSERT INTO items (Sold, ProductId) VALUES (false, (SELECT ProductId FROM products WHERE Name = 'Ring'))");
			migrationBuilder.Sql("INSERT INTO items (Sold, ProductId) VALUES (false, (SELECT ProductId FROM products WHERE Name = 'Ring'))");
			migrationBuilder.Sql("INSERT INTO items (Sold, ProductId) VALUES (false, (SELECT ProductId FROM products WHERE Name = 'Ring'))");
			migrationBuilder.Sql("INSERT INTO items (Sold, ProductId) VALUES (false, (SELECT ProductId FROM products WHERE Name = 'Ring'))");
			migrationBuilder.Sql("INSERT INTO items (Sold, ProductId) VALUES (false, (SELECT ProductId FROM products WHERE Name = 'Earring'))");
			migrationBuilder.Sql("INSERT INTO items (Sold, ProductId) VALUES (false, (SELECT ProductId FROM products WHERE Name = 'Earring'))");
			migrationBuilder.Sql("INSERT INTO items (Sold, ProductId) VALUES (false, (SELECT ProductId FROM products WHERE Name = 'Earring'))");
			migrationBuilder.Sql("INSERT INTO items (Sold, ProductId) VALUES (false, (SELECT ProductId FROM products WHERE Name = 'Earring'))");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
