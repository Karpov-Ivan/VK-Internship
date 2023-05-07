using System;
using Microsoft.EntityFrameworkCore;

namespace DBCore
{
    public class BaseRepository
    {
        protected readonly Context _context;

        public BaseRepository(Context context)
        {
            _context = context;
        }
    }
}

