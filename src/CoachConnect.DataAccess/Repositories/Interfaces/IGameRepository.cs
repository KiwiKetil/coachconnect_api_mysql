﻿using CoachConnect.DataAccess.Entities;
using CoachConnect.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachConnect.DataAccess.Repositories.Interfaces;
public interface IGameRepository
{
    Task<ICollection<Game>> GetAllAsync(GameQuery gameQuery);
    Task<Game?> GetByIdAsync(GameId id);
    Task<ICollection<Game>> GetByGameTimeAsync(DateTime gameTime);
    Task<Game?> UpdateAsync(GameId id, Game game);
    Task<Game?> CreateAsync(Game game);
    Task<Game?> DeleteAsync(GameId id); 
}
