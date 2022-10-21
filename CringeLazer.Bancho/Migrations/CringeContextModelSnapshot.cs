﻿// <auto-generated />
using System;
using System.Collections.Generic;
using CringeLazer.Application.Database;
using CringeLazer.Core.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CringeLazer.Bancho.Migrations
{
    [DbContext(typeof(CringeContext))]
    partial class CringeContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.HasPostgresEnum(modelBuilder, "countries", new[] { "unknown", "bd", "be", "bf", "bg", "ba", "bb", "wf", "bl", "bm", "bn", "bo", "bh", "bi", "bj", "bt", "jm", "bv", "bw", "ws", "bq", "br", "bs", "je", "by", "bz", "ru", "rw", "rs", "tl", "re", "tm", "tj", "ro", "tk", "gw", "gu", "gt", "gs", "gr", "gq", "gp", "jp", "gy", "gg", "gf", "ge", "gd", "gb", "ga", "sv", "gn", "gm", "gl", "gi", "gh", "om", "tn", "jo", "hr", "ht", "hu", "hk", "hn", "hm", "ve", "pr", "ps", "pw", "pt", "sj", "py", "iq", "pa", "pf", "pg", "pe", "pk", "ph", "pn", "pl", "pm", "zm", "eh", "ee", "eg", "za", "ec", "it", "vn", "sb", "et", "so", "zw", "sa", "es", "er", "me", "md", "mg", "mf", "ma", "mc", "uz", "mm", "ml", "mo", "mn", "mh", "mk", "mu", "mt", "mw", "mv", "mq", "mp", "ms", "mr", "im", "ug", "tz", "my", "mx", "il", "fr", "io", "sh", "fi", "fj", "fk", "fm", "fo", "ni", "nl", "no", "na", "vu", "nc", "ne", "nf", "ng", "nz", "np", "nr", "nu", "ck", "xk", "ci", "ch", "co", "cn", "cm", "cl", "cc", "ca", "cg", "cf", "cd", "cz", "cy", "cx", "cr", "cw", "cv", "cu", "sz", "sy", "sx", "kg", "ke", "ss", "sr", "ki", "kh", "kn", "km", "st", "sk", "kr", "si", "kp", "kw", "sn", "sm", "sl", "sc", "kz", "ky", "sg", "se", "sd", "do", "dm", "dj", "dk", "vg", "de", "ye", "dz", "us", "uy", "yt", "um", "lb", "lc", "la", "tv", "tw", "tt", "tr", "lk", "li", "lv", "to", "lt", "lu", "lr", "ls", "th", "tf", "tg", "td", "tc", "ly", "va", "vc", "ae", "ad", "ag", "af", "ai", "vi", "is", "ir", "am", "al", "ao", "aq", "as", "ar", "au", "at", "aw", "in", "ax", "az", "ie", "id", "ua", "qa", "mz" });
            NpgsqlModelBuilderExtensions.HasPostgresEnum(modelBuilder, "gamemode", new[] { "osu", "mania", "taiko", "fruits" });
            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CringeLazer.Core.Models.SessionModel", b =>
                {
                    b.Property<long>("SessionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("session_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("SessionId"));

                    b.Property<string>("RefreshToken")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("refresh_token");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint")
                        .HasColumnName("user_id");

                    b.HasKey("SessionId");

                    b.HasIndex("RefreshToken")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("session", (string)null);
                });

            modelBuilder.Entity("CringeLazer.Core.Models.Statistics.StatisticsModel", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnType("bigint")
                        .HasColumnName("user_id");

                    b.Property<Gamemode>("Gamemode")
                        .HasColumnType("gamemode")
                        .HasColumnName("gamemode");

                    b.Property<double>("Accuracy")
                        .HasColumnType("double precision")
                        .HasColumnName("accuracy");

                    b.Property<int?>("CountryRank")
                        .HasColumnType("integer")
                        .HasColumnName("country_rank");

                    b.Property<int?>("GlobalRank")
                        .HasColumnType("integer")
                        .HasColumnName("global_rank");

                    b.Property<bool>("IsRanked")
                        .HasColumnType("boolean")
                        .HasColumnName("is_ranked");

                    b.Property<int>("MaxCombo")
                        .HasColumnType("integer")
                        .HasColumnName("max_combo");

                    b.Property<decimal?>("PP")
                        .HasColumnType("numeric")
                        .HasColumnName("pp");

                    b.Property<int>("PlayCount")
                        .HasColumnType("integer")
                        .HasColumnName("playcount");

                    b.Property<int?>("PlayTime")
                        .HasColumnType("integer")
                        .HasColumnName("playtime");

                    b.Property<List<int>>("RankHistory")
                        .HasColumnType("integer[]")
                        .HasColumnName("rank_history");

                    b.Property<long>("RankedScore")
                        .HasColumnType("bigint")
                        .HasColumnName("ranked_score");

                    b.Property<int>("ReplaysWatched")
                        .HasColumnType("integer")
                        .HasColumnName("replays_watched");

                    b.Property<int>("TotalHits")
                        .HasColumnType("integer")
                        .HasColumnName("total_hits");

                    b.Property<long>("TotalScore")
                        .HasColumnType("bigint")
                        .HasColumnName("total_score");

                    b.HasKey("UserId", "Gamemode");

                    b.ToTable("statistic", (string)null);
                });

            modelBuilder.Entity("CringeLazer.Core.Models.Users.UserModel", b =>
                {
                    b.Property<long>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("user_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("UserId"));

                    b.Property<Countries>("Country")
                        .HasColumnType("countries")
                        .HasColumnName("country");

                    b.Property<string>("Discord")
                        .HasColumnType("text")
                        .HasColumnName("discord");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("Interests")
                        .HasColumnType("text")
                        .HasColumnName("interests");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean")
                        .HasColumnName("is_active");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("boolean")
                        .HasColumnName("is_admin");

                    b.Property<bool>("IsBNG")
                        .HasColumnType("boolean")
                        .HasColumnName("is_bng");

                    b.Property<bool>("IsBot")
                        .HasColumnType("boolean")
                        .HasColumnName("is_bot");

                    b.Property<bool>("IsGMT")
                        .HasColumnType("boolean")
                        .HasColumnName("is_gmt");

                    b.Property<bool>("IsQAT")
                        .HasColumnType("boolean")
                        .HasColumnName("is_qat");

                    b.Property<bool>("IsSupporter")
                        .HasColumnType("boolean")
                        .HasColumnName("is_supporter");

                    b.Property<DateTime>("JoinDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("join_date");

                    b.Property<DateTime>("LastVisit")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("last_visit");

                    b.Property<string>("Location")
                        .HasColumnType("text")
                        .HasColumnName("location");

                    b.Property<string>("Occupation")
                        .HasColumnType("text")
                        .HasColumnName("occupation");

                    b.Property<bool>("PMFriendsOnly")
                        .HasColumnType("boolean")
                        .HasColumnName("pm_friends_only");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("password");

                    b.Property<List<string>>("PreviousUsernames")
                        .IsRequired()
                        .HasColumnType("text[]")
                        .HasColumnName("previous_usernames");

                    b.Property<int>("SupportLevel")
                        .HasColumnType("integer")
                        .HasColumnName("support_level");

                    b.Property<string>("Title")
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.Property<string>("Twitter")
                        .HasColumnType("text")
                        .HasColumnName("twitter");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("username");

                    b.Property<string>("Website")
                        .HasColumnType("text")
                        .HasColumnName("website");

                    b.HasKey("UserId");

                    b.ToTable("user", (string)null);
                });

            modelBuilder.Entity("CringeLazer.Core.Models.SessionModel", b =>
                {
                    b.HasOne("CringeLazer.Core.Models.Users.UserModel", "User")
                        .WithMany("Sessions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("CringeLazer.Core.Models.Statistics.StatisticsModel", b =>
                {
                    b.HasOne("CringeLazer.Core.Models.Users.UserModel", "User")
                        .WithMany("Statistics")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("CringeLazer.Core.Models.Statistics.Grades", "Grades", b1 =>
                        {
                            b1.Property<long>("StatisticsModelUserId")
                                .HasColumnType("bigint");

                            b1.Property<Gamemode>("StatisticsModelGamemode")
                                .HasColumnType("gamemode");

                            b1.Property<int>("A")
                                .HasColumnType("integer")
                                .HasColumnName("grades_a");

                            b1.Property<int>("S")
                                .HasColumnType("integer")
                                .HasColumnName("grades_s");

                            b1.Property<int>("SPlus")
                                .HasColumnType("integer")
                                .HasColumnName("grades_splus");

                            b1.Property<int>("SS")
                                .HasColumnType("integer")
                                .HasColumnName("grades_ss");

                            b1.Property<int>("SSPlus")
                                .HasColumnType("integer")
                                .HasColumnName("grades_ssplus");

                            b1.HasKey("StatisticsModelUserId", "StatisticsModelGamemode");

                            b1.ToTable("statistic");

                            b1.WithOwner()
                                .HasForeignKey("StatisticsModelUserId", "StatisticsModelGamemode");
                        });

                    b.OwnsOne("CringeLazer.Core.Models.Statistics.LevelInfo", "Level", b1 =>
                        {
                            b1.Property<long>("StatisticsModelUserId")
                                .HasColumnType("bigint");

                            b1.Property<Gamemode>("StatisticsModelGamemode")
                                .HasColumnType("gamemode");

                            b1.Property<int>("Current")
                                .HasColumnType("integer")
                                .HasColumnName("level_current");

                            b1.Property<int>("Progress")
                                .HasColumnType("integer")
                                .HasColumnName("level_progress");

                            b1.HasKey("StatisticsModelUserId", "StatisticsModelGamemode");

                            b1.ToTable("statistic");

                            b1.WithOwner()
                                .HasForeignKey("StatisticsModelUserId", "StatisticsModelGamemode");
                        });

                    b.Navigation("Grades");

                    b.Navigation("Level");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CringeLazer.Core.Models.Users.UserModel", b =>
                {
                    b.OwnsMany("CringeLazer.Core.Models.Users.Achievement", "Achievements", b1 =>
                        {
                            b1.Property<long>("AchievementAwardId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("bigint")
                                .HasColumnName("achievement_award_id");

                            NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b1.Property<long>("AchievementAwardId"));

                            b1.Property<DateTime>("AchievedAt")
                                .HasColumnType("timestamp with time zone")
                                .HasColumnName("achieved_at");

                            b1.Property<int>("AchievementId")
                                .HasColumnType("integer")
                                .HasColumnName("achievement_id");

                            b1.Property<long>("UserId")
                                .HasColumnType("bigint")
                                .HasColumnName("user_id");

                            b1.HasKey("AchievementAwardId");

                            b1.HasIndex("UserId");

                            b1.ToTable("achievement", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsMany("CringeLazer.Core.Models.Users.Badge", "Badges", b1 =>
                        {
                            b1.Property<long>("BadgeId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("bigint")
                                .HasColumnName("badge_id");

                            NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b1.Property<long>("BadgeId"));

                            b1.Property<DateTime>("AwardedAt")
                                .HasColumnType("timestamp with time zone")
                                .HasColumnName("awarded_at");

                            b1.Property<string>("Description")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("description");

                            b1.Property<string>("ImageUrl")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("image_url");

                            b1.Property<long>("UserId")
                                .HasColumnType("bigint")
                                .HasColumnName("user_id");

                            b1.HasKey("BadgeId");

                            b1.HasIndex("UserId");

                            b1.ToTable("badge", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("CringeLazer.Core.Models.Users.Kudosu", "Kudosu", b1 =>
                        {
                            b1.Property<long>("UserModelUserId")
                                .HasColumnType("bigint");

                            b1.Property<int>("Available")
                                .HasColumnType("integer")
                                .HasColumnName("kudosu_available");

                            b1.Property<int>("Total")
                                .HasColumnType("integer")
                                .HasColumnName("kudosu_total");

                            b1.HasKey("UserModelUserId");

                            b1.ToTable("user");

                            b1.WithOwner()
                                .HasForeignKey("UserModelUserId");
                        });

                    b.Navigation("Achievements");

                    b.Navigation("Badges");

                    b.Navigation("Kudosu");
                });

            modelBuilder.Entity("CringeLazer.Core.Models.Users.UserModel", b =>
                {
                    b.Navigation("Sessions");

                    b.Navigation("Statistics");
                });
#pragma warning restore 612, 618
        }
    }
}
