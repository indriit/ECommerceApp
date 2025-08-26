using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerceApp.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    category_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.category_id);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    customer_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    first_name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    last_name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    email = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    password = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    address = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    phone_number = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.customer_id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    product_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    description = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    price = table.Column<string>(type: "decimal(10,2)", nullable: false),
                    stock = table.Column<string>(type: "TEXT", nullable: false),
                    Category_category_id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.product_id);
                    table.ForeignKey(
                        name: "FK_Product_Category",
                        column: x => x.Category_category_id,
                        principalTable: "Category",
                        principalColumn: "category_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    payment_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    payment_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    payment_method = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    amount = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Customer_customer_id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.payment_id);
                    table.ForeignKey(
                        name: "FK_Payment_Customer",
                        column: x => x.Customer_customer_id,
                        principalTable: "Customer",
                        principalColumn: "customer_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Shipment",
                columns: table => new
                {
                    shipment_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    shipment_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    address = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    city = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    state = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    country = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    zip_code = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    Customer_customer_id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shipment", x => x.shipment_id);
                    table.ForeignKey(
                        name: "FK_Shipment_Customer",
                        column: x => x.Customer_customer_id,
                        principalTable: "Customer",
                        principalColumn: "customer_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    cart_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    Customer_customer_id = table.Column<int>(type: "INTEGER", nullable: false),
                    Product_product_id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.cart_id);
                    table.ForeignKey(
                        name: "FK_Cart_Customer",
                        column: x => x.Customer_customer_id,
                        principalTable: "Customer",
                        principalColumn: "customer_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cart_Product",
                        column: x => x.Product_product_id,
                        principalTable: "Product",
                        principalColumn: "product_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Wishlist",
                columns: table => new
                {
                    wishlist_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Customer_customer_id = table.Column<int>(type: "INTEGER", nullable: false),
                    Product_product_id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wishlist", x => x.wishlist_id);
                    table.ForeignKey(
                        name: "FK_Wishlist_Customer",
                        column: x => x.Customer_customer_id,
                        principalTable: "Customer",
                        principalColumn: "customer_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Wishlist_Product",
                        column: x => x.Product_product_id,
                        principalTable: "Product",
                        principalColumn: "product_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    order_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    order_date = table.Column<DateTime>(type: "datetime", nullable: false),
                    total_price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    CustomerID = table.Column<int>(type: "INTEGER", nullable: false),
                    PaymentID = table.Column<int>(type: "INTEGER", nullable: false),
                    ShipmentID = table.Column<int>(type: "INTEGER", nullable: false),
                    Customer_customer_id = table.Column<int>(type: "INTEGER", nullable: false),
                    Payment_payment_id = table.Column<int>(type: "INTEGER", nullable: false),
                    Shipment_shipment_id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.order_id);
                    table.ForeignKey(
                        name: "FK_Order_Customer",
                        column: x => x.Customer_customer_id,
                        principalTable: "Customer",
                        principalColumn: "customer_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Customer_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customer",
                        principalColumn: "customer_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Payment",
                        column: x => x.Payment_payment_id,
                        principalTable: "Payment",
                        principalColumn: "payment_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Payment_PaymentID",
                        column: x => x.PaymentID,
                        principalTable: "Payment",
                        principalColumn: "payment_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Shipment",
                        column: x => x.Shipment_shipment_id,
                        principalTable: "Shipment",
                        principalColumn: "shipment_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Shipment_ShipmentID",
                        column: x => x.ShipmentID,
                        principalTable: "Shipment",
                        principalColumn: "shipment_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order_Item",
                columns: table => new
                {
                    order_item_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Order_order_id = table.Column<int>(type: "INTEGER", nullable: false),
                    Product_product_id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order_Item", x => x.order_item_id);
                    table.ForeignKey(
                        name: "FK_OrderItem_Order",
                        column: x => x.Order_order_id,
                        principalTable: "Order",
                        principalColumn: "order_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItem_Product",
                        column: x => x.Product_product_id,
                        principalTable: "Product",
                        principalColumn: "product_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cart_Customer_customer_id",
                table: "Cart",
                column: "Customer_customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_Product_product_id",
                table: "Cart",
                column: "Product_product_id");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Customer_customer_id",
                table: "Order",
                column: "Customer_customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_Order_CustomerID",
                table: "Order",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Payment_payment_id",
                table: "Order",
                column: "Payment_payment_id");

            migrationBuilder.CreateIndex(
                name: "IX_Order_PaymentID",
                table: "Order",
                column: "PaymentID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Shipment_shipment_id",
                table: "Order",
                column: "Shipment_shipment_id");

            migrationBuilder.CreateIndex(
                name: "IX_Order_ShipmentID",
                table: "Order",
                column: "ShipmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Item_Order_order_id",
                table: "Order_Item",
                column: "Order_order_id");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Item_Product_product_id",
                table: "Order_Item",
                column: "Product_product_id");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_Customer_customer_id",
                table: "Payment",
                column: "Customer_customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Category_category_id",
                table: "Product",
                column: "Category_category_id");

            migrationBuilder.CreateIndex(
                name: "IX_Shipment_Customer_customer_id",
                table: "Shipment",
                column: "Customer_customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_Wishlist_Customer_customer_id",
                table: "Wishlist",
                column: "Customer_customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_Wishlist_Product_product_id",
                table: "Wishlist",
                column: "Product_product_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropTable(
                name: "Order_Item");

            migrationBuilder.DropTable(
                name: "Wishlist");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "Shipment");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Customer");
        }
    }
}
