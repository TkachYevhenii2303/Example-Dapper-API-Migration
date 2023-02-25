﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Dapper_Data_Access_Layer.Context;
using Dapper_Data_Access_Layer.Entities;
using Dapper_Data_Access_Layer.Repository.Contracts.Interfaces;
using Dapper_Example_Bussines_Logic.Dto;
using Microsoft.Data.SqlClient;

namespace Dapper_Data_Access_Layer.Repository.Contracts
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly DapperContext _context;
        public CompanyRepository(DapperContext context) => _context = context;
        public async Task<IEnumerable<Clinic>> GetCompanies()
        {
            var query = "Select * From dbo.Clinic";
            using (var connection = _context.CreateConnection())
            {
                var companies = await connection.QueryAsync<Clinic>(query);
                return companies.ToList();
            }
        }

        public async Task<Clinic> GetCompany(int id)
        {
            var query = "Select * From dbo.Clinic Where Id = @Id";

            using (var connection = _context.CreateConnection())
            {
                var company = await connection.QuerySingleOrDefaultAsync<Clinic>(query, new { id });
                return company;
            }
        }

        public async Task<Clinic> CreateCompany(CompanyForCreationDto company)
        {
            var query = "Insert into Clinic (Clinic_name, Address, Details) Values (@Clinic_name, @Address, @Details) " +
                        "Select Cast(Scope_Identity() as int)";
            var parameters = new DynamicParameters();

            parameters.Add("Clinic_name", company.Clinic_name, DbType.String);
            parameters.Add("Address", company.Address, DbType.String);
            parameters.Add("Details", company.Details, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                var id = await connection.QuerySingleAsync<int>(query, parameters);

                var createdCompany = new Clinic
                {
                    Id = id,
                    Clinic_name = company.Clinic_name,
                    Address = company.Address,
                    Details = company.Details
                };

                return createdCompany;
            }
        }
    }
}