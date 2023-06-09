﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorEcommerce.Server.Migrations
{
    public partial class ProductSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImageUrl", "Price", "Title" },
                values: new object[] { 1, "Among the ashes of a dying world, an agent of the Commandment finds a letter. It reads: Burn before reading.\r\n\r\nThus begins an unlikely correspondence between two rival agents hellbent on securing the best possible future for their warring factions. Now, what began as a taunt, a battlefield boast, becomes something more. Something epic. Something romantic. Something that could change the past and the future.\r\n\r\nExcept the discovery of their bond would mean the death of each of them. There’s still a war going on, after all. And someone has to win. That’s how war works, right?\r\n\r\nCowritten by two beloved and award-winning sci-fi writers, This Is How You Lose the Time War is an epic love story spanning time and space.", "https://m.media-amazon.com/images/I/413wMSCwmML._SX331_BO1,204,203,200_.jpg", 9.99m, "This Is How You Lose the Time War" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImageUrl", "Price", "Title" },
                values: new object[] { 2, "Chemist Elizabeth Zott is not your average woman. In fact, Elizabeth Zott would be the first to point out that there is no such thing as an average woman. But it’s the early 1960s and her all-male team at Hastings Research Institute takes a very unscientific view of equality. Except for one: Calvin Evans; the lonely, brilliant, Nobel–prize nominated grudge-holder who falls in love with—of all things—her mind. True chemistry results. \r\n\r\nBut like science, life is unpredictable. Which is why a few years later Elizabeth Zott finds herself not only a single mother, but the reluctant star of America’s most beloved cooking show Supper at Six. Elizabeth’s unusual approach to cooking (“combine one tablespoon acetic acid with a pinch of sodium chloride”) proves revolutionary. But as her following grows, not everyone is happy. Because as it turns out, Elizabeth Zott isn’t just teaching women to cook. She’s daring them to change the status quo.  \r\n\r\nLaugh-out-loud funny, shrewdly observant, and studded with a dazzling cast of supporting characters, Lessons in Chemistry is as original and vibrant as its protagonist.", "https://m.media-amazon.com/images/I/71yNgTMEcpL.jpg", 12.99m, "Lessons in Chemistry: A Novel" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImageUrl", "Price", "Title" },
                values: new object[] { 3, "Trauma is a fact of life. Veterans and their families deal with the painful aftermath of combat; one in five Americans has been molested; one in four grew up with alcoholics; one in three couples have engaged in physical violence. Dr. Bessel van der Kolk, one of the world’s foremost experts on trauma, has spent over three decades working with survivors. In The Body Keeps the Score, he uses recent scientific advances to show how trauma literally reshapes both body and brain, compromising sufferers’ capacities for pleasure, engagement, self-control, and trust. He explores innovative treatments—from neurofeedback and meditation to sports, drama, and yoga—that offer new paths to recovery by activating the brain’s natural neuroplasticity. Based on Dr. van der Kolk’s own research and that of other leading specialists, The Body Keeps the Score exposes the tremendous power of our relationships both to hurt and to heal—and offers new hope for reclaiming lives.", "https://m.media-amazon.com/images/I/41T-XHe8-EL._SX323_BO1,204,203,200_.jpg", 21.99m, "The Body Keeps the Score: Brain, Mind, and Body in the Healing of Trauma" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
