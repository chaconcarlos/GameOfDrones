using GameOfDrones.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesOfDrones.Data.ADO
{
  /// <summary>
  /// Represents the EF data context for Game Of Drones.
  /// </summary>
  class GameEngineContext : DbContext
  {
    public GameEngineContext()
      : base("name=GameOfDronesDb")
    {
      //Database.SetInitializer<GameEngineContext>(null);
    }

    /// <summary>
    /// The games on the DB.
    /// </summary>
    public DbSet<GameData> Games { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      modelBuilder.Entity<GameData>().HasKey(g => g.Id);
      modelBuilder.Entity<GameData>().Property(g => g.Id)
             .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
      base.OnModelCreating(modelBuilder);
    }
  }
}
