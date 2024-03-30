using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Rockaway.WebApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artists",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Slug = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Venues",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Slug = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryCode = table.Column<string>(type: "varchar(2)", unicode: false, maxLength: 2, nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebsiteUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venues", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "Id", "Description", "Name", "Slug" },
                values: new object[,]
                {
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa10"), "Enigmatic and mysterious, Java’s Crypt are shrouded in secrecy, their enigmatic melodies and cryptic lyrics take listeners on a thrilling journey through the unknown realms of music.", "Java’s Crypt", "javas-crypt" },
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa11"), "An electrifying whirlwind, Killer Bite unleash a torrent of energy through their performances, captivating audiences with their explosive riffs and heart-pounding rhythms.", "Killer Bite", "killer-bite" },
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa12"), "Pioneers of progressive rock, Lambda of God is an innovative band that pushes the boundaries of musical expression, combining intricate compositions and thought-provoking lyrics that resonate deeply with their dedicated fanbase.", "Lambda of God", "lambda-of-god" },
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa13"), "Quirky and witty, the Null Terminated String Band is a rock group that weaves clever humor and geeky references into their catchy tunes, bringing a smile to the faces of both tech enthusiasts and music lovers alike.", "Null Terminated String Band", "null-terminated-string-band" },
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa14"), "A charismatic ensemble, Mott the Tuple blends vintage charm with a modern edge, creating a unique sound that captivates audiences and takes them on a nostalgic journey through time.", "Mott the Tuple", "mott-the-tuple" },
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa15"), "Overflowing with passion and intensity, Överflow is a rock band that immerses listeners in a tsunami of sound, exploring emotions through powerful melodies and soul-stirring performances.", "Överflow", "overflow" },
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa16"), "Philosophers of rock, Pascal’s Wager delves into existential themes with their intellectually charged songs, prompting listeners to ponder the profound questions of life and purpose.", "Pascal’s Wager", "pascals-wager" },
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa17"), "Futuristic and avant-garde, Qüantum Gäte defy conventions, using experimental sounds and innovative compositions to transport listeners to other dimensions of music.", "Qüantum Gäte", "quantum-gate" },
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa18"), "High-energy and rebellious, Run CMD is a rock band that merges technology themes with headbanging-worthy tunes, igniting the stage with their electrifying presence and infectious enthusiasm.", "Run CMD", "run-cmd" },
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa19"), "Mischievous and bold, <Script>Kiddies subvert expectations with clever musical pranks, weaving clever wordplay and tongue-in-cheek humor into their audacious performances.", "<Script>Kiddies", "script-kiddies" },
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa20"), "Masters of atmosphere, Terrorform’s dark and atmospheric rock ensembles conjure hauntingly beautiful soundscapes that captivate the senses and evoke a deep emotional response.", "Terrorform", "terrorform" },
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa21"), "ᵾnɨȼøđɇɍ harmonize complex equations and melodies, weaving a symphony of logic and emotion in their unique and captivating music.", "ᵾnɨȼøđɇɍ", "unicoder" },
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa22"), "Bridging reality and virtuality, Virtual Machine is a surreal rock group that blurs the lines between the tangible and the digital, creating mind-bending performances that leave audiences questioning the nature of existence.", "Virtual Machine", "virtual-machine" },
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa23"), "Technologically savvy and creatively ambitious, Webmaster of Puppets is a web-inspired rock band, crafting narratives of digital dominance and manipulation with their inventive music.", "Webmaster of Puppets", "webmaster-of-puppets" },
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa24"), "Mesmerizing and genre-defying, XSLTE is an enchanting rock ensemble that fuses electronic and rock elements, creating a spellbinding sound that enthralls listeners and transports them to MakeArtist sonic landscapes.", "XSLTE", "xslte" },
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa25"), "Youthful and exuberant, YAMB spreads positivity and infectious energy through their music, connecting with fans through their youthful spirit and heartwarming performances.", "YAMB", "yamb" },
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa26"), "Innovative and exploratory, Zero Based Index starts from scratch, building powerful narratives through their dynamic sound, leaving audiences inspired and moved by their expressive and daring music.", "Zero Based Index", "zero-based-index" },
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa27"), "Inspired by their Australian namesakes, Ærbårn are Scandinavia's #1 party rock band. Thundering drums, huge guitar riffs and enough energy to light up the Arctic Circle, their shows have had amazing reviews all over the world", "Ærbårn", "aerbaarn" },
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa28"), "dot-dot-dot to their friends (and fans), ... are a Canadian drone jazz combo formed in Vancouver in 1998, known for their thunderous horn section and innovative visuals.", "...", "dot-dot-dot" },
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa29"), "Known as the \"Silver Mountain Strings\" if you're into the whole brevity thing, Kentucky's answer to the Leningrad Cowboys has gone from strength to strength, from the Superbowl half time show to their sold-out Vegas residency in 2023.", "The Silver Mountain String Band featuring Timber J. MacCorkindale and the Hill Valley Hornswogglers", "silver-mountain-string-band" },
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa1"), "Alter Column are South Africa's hottest math rock export. Founded in Cape Town in 2021, their debut album \"Drop Table Mountain\" was nominated for four Grammy awards.", "Alter Column", "alter-column" },
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa2"), "Speed metal pioneers from San Francisco, <Body>Bag helped define the “web rock” sound in the early 2020s.", "<Body>Bag", "body-bag" },
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa3"), "Hailing from a distant future, Coda is a time-traveling rock band known for their mind-bending melodies that transport audiences through different eras, merging past and future into a harmonious blend of sound.", "Coda", "coda" },
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa4"), "Rising from the ashes of adversity, Dev Leppard is a fiercely talented rock band that overcame obstacles with sheer determination, captivating fans worldwide with their electrifying performances and showcasing a bond that empowers their music.", "Dev Leppard", "dev-leppard" },
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa5"), "Merging the realms of art and emotion, Электроника is an introspective rock group, infusing their hauntingly beautiful lyrics with mesmerizing melodies that delve into the depths of human existence, leaving listeners immersed in profound reflections.", "Электроника", "elektronika" },
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa6"), "With an otherworldly allure, For Ear Transform is an ethereal rock ensemble, their music transcends reality, leading listeners on a dreamlike journey where celestial harmonies and ethereal instrumentation create a captivating and transformative experience.", "For Ear Transform", "for-ear-transform" },
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa7"), "Rebel rockers with a cause, Garbage Collectors are raw, raucous and unapologetic, fearlessly tackling social issues and societal norms in their music, energizing crowds with their powerful anthems and unyielding spirit.", "Garbage Collectors", "garbage-collectors" },
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa8"), "Virtuosos of rhythm and harmony, Haskell’s Angels radiate a divine aura, blending complex melodies and celestial harmonies that resonate deep within the soul.", "Haskell’s Angels", "haskells-angels" },
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa9"), "A force to be reckoned with, Iron Median are known for their thunderous beats and adrenaline-pumping anthems, electrifying audiences with their commanding stage presence and unstoppable energy.", "Iron Median", "iron-median" }
                });

            migrationBuilder.InsertData(
                table: "Venues",
                columns: new[] { "Id", "Address", "City", "CountryCode", "Name", "PostalCode", "Slug", "Telephone", "WebsiteUrl" },
                values: new object[,]
                {
                    { new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb1"), "Town Hall Parade", "London", "GB", "Electric Brixton", "SW2 1RJ", "electric-brixton", "020 7274 2290", "https://www.electricbrixton.uk.com/" },
                    { new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb2"), "50 Boulevard Voltaire", "Paris", "FR", "Bataclan", "75011", "bataclan-paris", "+33 1 43 14 00 30", "https://www.bataclan.fr/" },
                    { new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb3"), "Columbiadamm 9 - 11", "Berlin", "DE", "Columbia Theatre", "10965", "columbia-berlin", "+49 30 69817584", "https://columbia-theater.de/" },
                    { new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb4"), "Liosion 205", "Athens", "GR", "Gagarin 205", "104 45", "gagarin-athens", "+45 35 35 50 69", "" },
                    { new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb5"), "Torggata 16", "Oslo", "NO", "John Dee Live Club & Pub", "0181", "john-dee-oslo", "+47 22 20 32 32", "https://www.rockefeller.no/" },
                    { new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb6"), "Stengade 18", "Copenhagen", "DK", "Stengade", "2200", "stengade-copenhagen", "+45 35355069", "https://www.stengade.dk" },
                    { new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb7"), "R da Madeira 186", "Porto", "PT", "Barracuda", "4000-433", "barracuda-porto", null, null },
                    { new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb8"), "Sveavägen 90", "Stockholm", "SE", "Pub Anchor", "113 59", "pub-anchor-stockholm", "+46 8 15 20 00", "https://www.instagram.com/pubanchor/?hl=en" },
                    { new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb9"), "323 New Cross Road", "London", "GB", "New Cross Inn", "SE14 6AS", "new-cross-inn-london", "+44 20 8469 4382", "https://www.newcrossinn.com/" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Artists");

            migrationBuilder.DropTable(
                name: "Venues");
        }
    }
}
