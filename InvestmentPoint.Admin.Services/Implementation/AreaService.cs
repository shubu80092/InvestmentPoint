using InvestmentPoint.Admin.Domain.Common;
using InvestmentPoint.Admin.Domain.Entites;
using InvestmentPoint.Admin.Persistence;
using InvestmentPoint.Admin.Services.Contract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentPoint.Admin.Services.Implementation
{
    public class AreaService : IAreaService
    {
        private readonly ApplicationDbContext _context;
        public AreaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddArea(AreaModel model)
        {
            try
            {
                if (!string.IsNullOrEmpty(model.AreaName))
                {
                    Area area = new()
                    {
                        AreaName = model.AreaName
                    };
                    await _context.Areas.AddAsync(area);
                    await _context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Server Error" + ex.Message);
            }
        }

        public async Task<bool> DeleteArea(int id)
        {
            try
            {
                var result = await _context.Areas.FirstOrDefaultAsync(x => x.Id == id);
                if (!string.IsNullOrEmpty(result.AreaName))
                {
                     _context.Areas.Remove(result);
                    await _context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Server Error" + ex.Message);
            }
        }

        public async Task<bool> EditArea(int id,AreaModel model)
        {
            try
            {
                if(id > 0)
                {
                    var result = await _context.Areas.FirstOrDefaultAsync(x => x.Id == id);
                    if (!string.IsNullOrEmpty(result.AreaName))
                    {
                        result.AreaName = model.AreaName;
                        await _context.SaveChangesAsync();
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {

                throw new Exception("Server Error" + ex.Message);
            }
        }

        public async Task<IEnumerable> ListArea()
        {
            try
            {
                var list = await _context.Areas.ToListAsync();
                return list;
            }
            catch (Exception ex)
            {

                throw new Exception("Server Error" + ex.Message);
            }
        }

        public async Task<Area> ListAreaById(int id)
        {
            try
            {
             return await _context.Areas.FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {

                throw new Exception("Server Error" + ex.Message);
            }
        }
    }
}
