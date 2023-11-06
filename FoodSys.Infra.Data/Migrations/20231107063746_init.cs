using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FoodSys.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "COMPANY_PLAN",
                columns: table => new
                {
                    cp_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cp_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COMPANY_PLAN", x => x.cp_id);
                });

            migrationBuilder.CreateTable(
                name: "COMPANY_TYPE",
                columns: table => new
                {
                    ctp_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ctp_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COMPANY_TYPE", x => x.ctp_id);
                });

            migrationBuilder.CreateTable(
                name: "COUPON_VALUE_TYPE",
                columns: table => new
                {
                    cvt_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cvt_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COUPON_VALUE_TYPE", x => x.cvt_id);
                });

            migrationBuilder.CreateTable(
                name: "CUSTOMER_PLAN",
                columns: table => new
                {
                    p_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    p_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CUSTOMER_PLAN", x => x.p_id);
                });

            migrationBuilder.CreateTable(
                name: "DELIVERER_STATUS",
                columns: table => new
                {
                    ds_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ds_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DELIVERER_STATUS", x => x.ds_id);
                });

            migrationBuilder.CreateTable(
                name: "DELIVERER_VEHICLE",
                columns: table => new
                {
                    dv_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dv_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DELIVERER_VEHICLE", x => x.dv_id);
                });

            migrationBuilder.CreateTable(
                name: "ORDER_STATUS",
                columns: table => new
                {
                    os_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    os_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORDER_STATUS", x => x.os_id);
                });

            migrationBuilder.CreateTable(
                name: "COMPANY",
                columns: table => new
                {
                    cy_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    cy_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    cy_description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    cy_email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    cy_password = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    cy_cnpj = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    cy_type_id = table.Column<int>(type: "int", nullable: false),
                    cy_plan_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COMPANY", x => x.cy_id);
                    table.ForeignKey(
                        name: "FK_COMPANY_COMPANY_PLAN_cy_plan_id",
                        column: x => x.cy_plan_id,
                        principalTable: "COMPANY_PLAN",
                        principalColumn: "cp_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_COMPANY_COMPANY_TYPE_cy_type_id",
                        column: x => x.cy_type_id,
                        principalTable: "COMPANY_TYPE",
                        principalColumn: "ctp_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CUSTOMER",
                columns: table => new
                {
                    ct_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ct_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ct_email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ct_password_hash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    ct_password_salt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    ct_phonenumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    ct_birthday = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ct_cpf = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    ct_plan_id = table.Column<int>(type: "int", nullable: false),
                    ct_active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CUSTOMER", x => x.ct_id);
                    table.ForeignKey(
                        name: "FK_CUSTOMER_CUSTOMER_PLAN_ct_plan_id",
                        column: x => x.ct_plan_id,
                        principalTable: "CUSTOMER_PLAN",
                        principalColumn: "p_id");
                });

            migrationBuilder.CreateTable(
                name: "DELIVERER",
                columns: table => new
                {
                    d_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    d_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    d_email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    d_password = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    d_cnh = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    d_cpf = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    d_birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    d_phonenumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    d_cep = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    d_street = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    d_addressnumber = table.Column<int>(type: "int", maxLength: 8, nullable: false),
                    d_complement = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    d_status_id = table.Column<int>(type: "int", nullable: false),
                    d_vehicle_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DELIVERER", x => x.d_id);
                    table.ForeignKey(
                        name: "FK_DELIVERER_DELIVERER_STATUS_d_status_id",
                        column: x => x.d_status_id,
                        principalTable: "DELIVERER_STATUS",
                        principalColumn: "ds_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DELIVERER_DELIVERER_VEHICLE_d_vehicle_id",
                        column: x => x.d_vehicle_id,
                        principalTable: "DELIVERER_VEHICLE",
                        principalColumn: "dv_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MENU",
                columns: table => new
                {
                    m_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    m_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    m_description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    m_categories = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    m_price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    m_discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    m_image = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    m_is_active = table.Column<bool>(type: "bit", nullable: false),
                    m_company_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MENU", x => x.m_id);
                    table.ForeignKey(
                        name: "FK_MENU_COMPANY_m_company_id",
                        column: x => x.m_company_id,
                        principalTable: "COMPANY",
                        principalColumn: "cy_id");
                });

            migrationBuilder.CreateTable(
                name: "ADDRESS",
                columns: table => new
                {
                    a_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    a_cep = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    a_street = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    a_address_number = table.Column<int>(type: "int", nullable: false),
                    a_complement = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    a_receiver_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    a_costumer_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADDRESS", x => x.a_id);
                    table.ForeignKey(
                        name: "FK_ADDRESS_CUSTOMER_a_costumer_id",
                        column: x => x.a_costumer_id,
                        principalTable: "CUSTOMER",
                        principalColumn: "ct_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DELIVERER_MOTORCICLE",
                columns: table => new
                {
                    dm_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    dm_plate = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    dm_renavam = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    dm_model = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    dm_year = table.Column<int>(type: "int", nullable: false),
                    dm_brand = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    dm_deliverer_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DELIVERER_MOTORCICLE", x => x.dm_id);
                    table.ForeignKey(
                        name: "FK_DELIVERER_MOTORCICLE_DELIVERER_dm_deliverer_id",
                        column: x => x.dm_deliverer_id,
                        principalTable: "DELIVERER",
                        principalColumn: "d_id");
                });

            migrationBuilder.CreateTable(
                name: "COUPON",
                columns: table => new
                {
                    c_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    c_code = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    c_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    c_description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    c_menu_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    c_value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    c_value_type_id = table.Column<int>(type: "int", nullable: false),
                    c_company_type_id = table.Column<int>(type: "int", nullable: false),
                    c_plan_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COUPON", x => x.c_id);
                    table.ForeignKey(
                        name: "FK_COUPON_COMPANY_TYPE_c_company_type_id",
                        column: x => x.c_company_type_id,
                        principalTable: "COMPANY_TYPE",
                        principalColumn: "ctp_id");
                    table.ForeignKey(
                        name: "FK_COUPON_COUPON_VALUE_TYPE_c_value_type_id",
                        column: x => x.c_value_type_id,
                        principalTable: "COUPON_VALUE_TYPE",
                        principalColumn: "cvt_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_COUPON_CUSTOMER_PLAN_c_plan_id",
                        column: x => x.c_plan_id,
                        principalTable: "CUSTOMER_PLAN",
                        principalColumn: "p_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_COUPON_MENU_c_menu_id",
                        column: x => x.c_menu_id,
                        principalTable: "MENU",
                        principalColumn: "m_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "COUPON_COMPANY",
                columns: table => new
                {
                    cc_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    cc_coupon_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    cc_company_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COUPON_COMPANY", x => x.cc_id);
                    table.ForeignKey(
                        name: "FK_COUPON_COMPANY_COMPANY_cc_company_id",
                        column: x => x.cc_company_id,
                        principalTable: "COMPANY",
                        principalColumn: "cy_id");
                    table.ForeignKey(
                        name: "FK_COUPON_COMPANY_COUPON_cc_coupon_id",
                        column: x => x.cc_coupon_id,
                        principalTable: "COUPON",
                        principalColumn: "c_id");
                });

            migrationBuilder.CreateTable(
                name: "COUPON_COSTUMER",
                columns: table => new
                {
                    cct_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    cct_coupon_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    cct_costumer_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COUPON_COSTUMER", x => x.cct_id);
                    table.ForeignKey(
                        name: "FK_COUPON_COSTUMER_COUPON_cct_coupon_id",
                        column: x => x.cct_coupon_id,
                        principalTable: "COUPON",
                        principalColumn: "c_id");
                    table.ForeignKey(
                        name: "FK_COUPON_COSTUMER_CUSTOMER_cct_costumer_id",
                        column: x => x.cct_costumer_id,
                        principalTable: "CUSTOMER",
                        principalColumn: "ct_id");
                });

            migrationBuilder.CreateTable(
                name: "ORDER",
                columns: table => new
                {
                    o_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    o_costumer_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    o_company_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    o_coupon_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    o_deliverer_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    o_address_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    o_value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    o_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    o_status_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORDER", x => x.o_id);
                    table.ForeignKey(
                        name: "FK_ORDER_ADDRESS_o_address_id",
                        column: x => x.o_address_id,
                        principalTable: "ADDRESS",
                        principalColumn: "a_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ORDER_COMPANY_o_company_id",
                        column: x => x.o_company_id,
                        principalTable: "COMPANY",
                        principalColumn: "cy_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ORDER_COUPON_o_coupon_id",
                        column: x => x.o_coupon_id,
                        principalTable: "COUPON",
                        principalColumn: "c_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ORDER_CUSTOMER_o_costumer_id",
                        column: x => x.o_costumer_id,
                        principalTable: "CUSTOMER",
                        principalColumn: "ct_id");
                    table.ForeignKey(
                        name: "FK_ORDER_DELIVERER_o_deliverer_id",
                        column: x => x.o_deliverer_id,
                        principalTable: "DELIVERER",
                        principalColumn: "d_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ORDER_ORDER_STATUS_o_status_id",
                        column: x => x.o_status_id,
                        principalTable: "ORDER_STATUS",
                        principalColumn: "os_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ORDER_ITEM",
                columns: table => new
                {
                    oi_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    oi_menu_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    oi_amount = table.Column<int>(type: "int", nullable: false),
                    oi_value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    oi_order_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORDER_ITEM", x => x.oi_id);
                    table.ForeignKey(
                        name: "FK_ORDER_ITEM_MENU_oi_menu_id",
                        column: x => x.oi_menu_id,
                        principalTable: "MENU",
                        principalColumn: "m_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ORDER_ITEM_ORDER_oi_order_id",
                        column: x => x.oi_order_id,
                        principalTable: "ORDER",
                        principalColumn: "o_id");
                });

            migrationBuilder.InsertData(
                table: "COMPANY_PLAN",
                columns: new[] { "cp_id", "cp_name" },
                values: new object[,]
                {
                    { 1, "Basic" },
                    { 2, "Master" }
                });

            migrationBuilder.InsertData(
                table: "COMPANY_TYPE",
                columns: new[] { "ctp_id", "ctp_name" },
                values: new object[,]
                {
                    { 1, "Market" },
                    { 2, "Restaurant" }
                });

            migrationBuilder.InsertData(
                table: "COUPON_VALUE_TYPE",
                columns: new[] { "cvt_id", "cvt_name" },
                values: new object[,]
                {
                    { 1, "Percetage" },
                    { 2, "Value" }
                });

            migrationBuilder.InsertData(
                table: "CUSTOMER_PLAN",
                columns: new[] { "p_id", "p_name" },
                values: new object[,]
                {
                    { 1, "None" },
                    { 2, "Premium" }
                });

            migrationBuilder.InsertData(
                table: "DELIVERER_STATUS",
                columns: new[] { "ds_id", "ds_name" },
                values: new object[,]
                {
                    { 1, "Offline" },
                    { 2, "Online" },
                    { 3, "Work" }
                });

            migrationBuilder.InsertData(
                table: "DELIVERER_VEHICLE",
                columns: new[] { "dv_id", "dv_name" },
                values: new object[,]
                {
                    { 1, "Bike" },
                    { 2, "Motorcicle" }
                });

            migrationBuilder.InsertData(
                table: "ORDER_STATUS",
                columns: new[] { "os_id", "os_name" },
                values: new object[,]
                {
                    { 1, "Open" },
                    { 2, "Closed" },
                    { 3, "Canceled" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ADDRESS_a_costumer_id",
                table: "ADDRESS",
                column: "a_costumer_id");

            migrationBuilder.CreateIndex(
                name: "IX_COMPANY_cy_plan_id",
                table: "COMPANY",
                column: "cy_plan_id");

            migrationBuilder.CreateIndex(
                name: "IX_COMPANY_cy_type_id",
                table: "COMPANY",
                column: "cy_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_COUPON_c_company_type_id",
                table: "COUPON",
                column: "c_company_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_COUPON_c_menu_id",
                table: "COUPON",
                column: "c_menu_id");

            migrationBuilder.CreateIndex(
                name: "IX_COUPON_c_plan_id",
                table: "COUPON",
                column: "c_plan_id");

            migrationBuilder.CreateIndex(
                name: "IX_COUPON_c_value_type_id",
                table: "COUPON",
                column: "c_value_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_COUPON_COMPANY_cc_company_id",
                table: "COUPON_COMPANY",
                column: "cc_company_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_COUPON_COMPANY_cc_coupon_id",
                table: "COUPON_COMPANY",
                column: "cc_coupon_id");

            migrationBuilder.CreateIndex(
                name: "IX_COUPON_COSTUMER_cct_costumer_id",
                table: "COUPON_COSTUMER",
                column: "cct_costumer_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_COUPON_COSTUMER_cct_coupon_id",
                table: "COUPON_COSTUMER",
                column: "cct_coupon_id");

            migrationBuilder.CreateIndex(
                name: "IX_CUSTOMER_ct_plan_id",
                table: "CUSTOMER",
                column: "ct_plan_id");

            migrationBuilder.CreateIndex(
                name: "IX_DELIVERER_d_status_id",
                table: "DELIVERER",
                column: "d_status_id");

            migrationBuilder.CreateIndex(
                name: "IX_DELIVERER_d_vehicle_id",
                table: "DELIVERER",
                column: "d_vehicle_id");

            migrationBuilder.CreateIndex(
                name: "IX_DELIVERER_MOTORCICLE_dm_deliverer_id",
                table: "DELIVERER_MOTORCICLE",
                column: "dm_deliverer_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MENU_m_company_id",
                table: "MENU",
                column: "m_company_id");

            migrationBuilder.CreateIndex(
                name: "IX_ORDER_o_address_id",
                table: "ORDER",
                column: "o_address_id");

            migrationBuilder.CreateIndex(
                name: "IX_ORDER_o_company_id",
                table: "ORDER",
                column: "o_company_id");

            migrationBuilder.CreateIndex(
                name: "IX_ORDER_o_costumer_id",
                table: "ORDER",
                column: "o_costumer_id");

            migrationBuilder.CreateIndex(
                name: "IX_ORDER_o_coupon_id",
                table: "ORDER",
                column: "o_coupon_id");

            migrationBuilder.CreateIndex(
                name: "IX_ORDER_o_deliverer_id",
                table: "ORDER",
                column: "o_deliverer_id");

            migrationBuilder.CreateIndex(
                name: "IX_ORDER_o_status_id",
                table: "ORDER",
                column: "o_status_id");

            migrationBuilder.CreateIndex(
                name: "IX_ORDER_ITEM_oi_menu_id",
                table: "ORDER_ITEM",
                column: "oi_menu_id");

            migrationBuilder.CreateIndex(
                name: "IX_ORDER_ITEM_oi_order_id",
                table: "ORDER_ITEM",
                column: "oi_order_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "COUPON_COMPANY");

            migrationBuilder.DropTable(
                name: "COUPON_COSTUMER");

            migrationBuilder.DropTable(
                name: "DELIVERER_MOTORCICLE");

            migrationBuilder.DropTable(
                name: "ORDER_ITEM");

            migrationBuilder.DropTable(
                name: "ORDER");

            migrationBuilder.DropTable(
                name: "ADDRESS");

            migrationBuilder.DropTable(
                name: "COUPON");

            migrationBuilder.DropTable(
                name: "DELIVERER");

            migrationBuilder.DropTable(
                name: "ORDER_STATUS");

            migrationBuilder.DropTable(
                name: "CUSTOMER");

            migrationBuilder.DropTable(
                name: "COUPON_VALUE_TYPE");

            migrationBuilder.DropTable(
                name: "MENU");

            migrationBuilder.DropTable(
                name: "DELIVERER_STATUS");

            migrationBuilder.DropTable(
                name: "DELIVERER_VEHICLE");

            migrationBuilder.DropTable(
                name: "CUSTOMER_PLAN");

            migrationBuilder.DropTable(
                name: "COMPANY");

            migrationBuilder.DropTable(
                name: "COMPANY_PLAN");

            migrationBuilder.DropTable(
                name: "COMPANY_TYPE");
        }
    }
}
