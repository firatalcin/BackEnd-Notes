using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsNoTracking
{
    public class BenchmarkService
    {
        private class Config : ManualConfig
        {
            public Config()
            {
                SummaryStyle = BenchmarkDotNet.Reports.SummaryStyle.Default
                    .WithRatioStyle(BenchmarkDotNet.Columns.RatioStyle.Trend);
            }
        }

        [Benchmark(Baseline = true)]
        public void GetAllWithTracking()
        {
            AppDbContext context = new();
            context.Products.ToList();
        }

        [Benchmark]
        public void GetAllWithAsNoTracking()
        {
            AppDbContext context = new();
            context.Products.AsNoTracking().ToList();
        }

    }

}
