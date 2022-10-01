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
    public class InvestTypeServicecs : IInvestTypeServicecs
    {
        private readonly ApplicationDbContext _context;
        public InvestTypeServicecs(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddImvestType(InvestTypeModel model)
        {
            try
            {
                if (!string.IsNullOrEmpty(model.InvestmentName))
                {
                    TypeOfInvestment Invest = new()
                    {
                        InvestmentName = model.InvestmentName,
                    };
                    await _context.TypeofInvestments.AddAsync(Invest);
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

        public async Task<bool> DeleteInvestType(int id)
        {
            try
            {
                if(id > 0)
                {
                    var result = await _context.TypeofInvestments.FirstOrDefaultAsync(x => x.Id == id);
                    if(!string.IsNullOrEmpty(result.InvestmentName))
                    {
                        _context.Remove(result);
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

        public async Task<bool> EditImvestType(int id, InvestTypeModel model)
        {
            try
            {
                if(id > 0)
                {
                    var result = await _context.TypeofInvestments.FirstOrDefaultAsync(x => x.Id == id);
                    if (!string.IsNullOrEmpty(result.InvestmentName))
                    {
                        result.InvestmentName = model.InvestmentName;
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

        public async Task<TypeOfInvestment> ImvestTypeById(int id)
        {
            try
            {
                return await _context.TypeofInvestments.FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {

                throw new Exception("Server Error" + ex.Message);
            }
        }

        public async Task<IEnumerable> ListImvestType()
        {
            try
            {
                var list = await _context.TypeofInvestments.ToListAsync();
                return list;
            }
            catch (Exception ex)
            {

                throw new Exception("Server Error" + ex.Message);
            }
        }
    }
}
