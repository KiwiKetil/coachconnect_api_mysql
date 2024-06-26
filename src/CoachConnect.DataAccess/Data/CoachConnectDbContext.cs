﻿using CoachConnect.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoachConnect.DataAccess.Data;

public class CoachConnectDbContext : DbContext
{
    public CoachConnectDbContext(DbContextOptions<CoachConnectDbContext> options) : base(options)
    {

    }
    public DbSet<Coach> Coaches { get; set; }
    public DbSet<Game> Games { get; set; }
    public DbSet<GameAttendance> Game_attendences { get; set; }
    public DbSet<Player> Players { get; set; }
    public DbSet<Practice> Practices { get; set; }
    public DbSet<PracticeAttendance> Practice_attendences { get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<JwtRole> Jwt_roles { get; set; }
    public DbSet<JwtUserRole> Jwt_user_roles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        #region User

        modelBuilder.Entity<User>()
            .Property(x => x.Id)
            .HasConversion(
                id => id.userId,
                value => new UserId(value)
            );

        #endregion

        #region Coach
        modelBuilder.Entity<Coach>()
           .Property(x => x.Id)
           .HasConversion(
               id => id.coachId,
               value => new CoachId(value)
           );
        #endregion

        #region Player
        modelBuilder.Entity<Player>()
            .Property(x => x.Id)
            .HasConversion(
                id => id.playerId,
                value => new PlayerId(value)
            );

        modelBuilder.Entity<Player>()
           .Property(p => p.UserId)
           .HasConversion(
               v => v.userId,
               v => new UserId(v)
           );

        modelBuilder.Entity<Player>()
         .Property(x => x.TeamId)
         .HasConversion(
          id => id.teamId,
          value => new TeamId(value)
             );
        #endregion      

        #region Team
        modelBuilder.Entity<Team>()
            .Property(x => x.Id)
            .HasConversion(
                id => id.teamId,
                value => new TeamId(value)
            );

        modelBuilder.Entity<Team>()
       .Property(x => x.CoachId)
       .HasConversion(
           id => id.coachId,
           value => new CoachId(value)
        );
        #endregion

        #region Game
        modelBuilder.Entity<Game>()
            .Property(x => x.Id)
            .HasConversion(
                id => id.gameId,
                value => new GameId(value)
            );

        modelBuilder.Entity<Game>()
         .Property(x => x.HomeTeam)
         .HasConversion(
             id => id.teamId,
             value => new TeamId(value)
          );

        modelBuilder.Entity<Game>()
        .Property(x => x.AwayTeam)
        .HasConversion(
            id => id.teamId,
            value => new TeamId(value)
         );
        #endregion

        #region Gameattendance
        modelBuilder.Entity<GameAttendance>()
            .Property(x => x.Id)
            .HasConversion(
                id => id.gameAttendanceId,
                value => new GameAttendanceId(value)
            );

        modelBuilder.Entity<GameAttendance>()
          .Property(x => x.GameId)
          .HasConversion(
              id => id.gameId,
              value => new GameId(value)
          );

        modelBuilder.Entity<GameAttendance>()
           .Property(x => x.PlayerId)
           .HasConversion(
               id => id.playerId,
               value => new PlayerId(value)
           );
        #endregion

        #region Practice
        modelBuilder.Entity<Practice>()
            .Property(x => x.Id)
            .HasConversion(
                id => id.practiceId,
                value => new PracticeId(value)
            );
        #endregion

        #region PracticeAttendance
        modelBuilder.Entity<PracticeAttendance>()
            .Property(x => x.Id)
            .HasConversion(
                id => id.practiceAttendanceId,
                value => new PracticeAttendanceId(value)
            );

        modelBuilder.Entity<PracticeAttendance>()
         .Property(x => x.PlayerId)
         .HasConversion(
             id => id.playerId,
             value => new PlayerId(value)
           );

        modelBuilder.Entity<PracticeAttendance>()
          .Property(x => x.PracticeId)
          .HasConversion(
              id => id.practiceId,
              value => new PracticeId(value)
           );
        #endregion

        #region JwtUserRole
        modelBuilder.Entity<JwtUserRole>()
          .HasOne<JwtRole>()  
          .WithMany()         
          .HasForeignKey(u => u.JwtRoleId);

        modelBuilder.Entity<JwtUserRole>()
         .Property(x => x.Id)
         .HasConversion(
             id => id.jwtUserRoleId,
             value => new JwtUserRoleId(value)
         );
        #endregion  
    }
}