﻿using CringeLazer.Bancho.Domain;
using CringeLazer.Bancho.Domain.Chat;
using Microsoft.EntityFrameworkCore;

namespace CringeLazer.Bancho.Data;

public class CringeContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<ChatChannel> Channels { get; set; }
    public DbSet<Season> Seasons { get; set; }

    public CringeContext(DbContextOptions<CringeContext> options) : base(options)
    {
    }
}