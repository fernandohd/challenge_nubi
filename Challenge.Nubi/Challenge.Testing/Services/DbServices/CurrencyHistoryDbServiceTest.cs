using Challenge.Application.Services.DbServices;
using Challenge.Domain.Contexts;
using Challenge.Domain.Entities;
using Challenge.Testing.Bases;
using Challenge.Testing.Builders;
using Challenge.Testing.Mocks;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Challenge.Testing.Services.DbServices
{
    [TestFixture]
    public class CurrencyHistoryDbServiceTest : ServiceBaseTest<ChallengeDbContext, CurrencyHistoryEntity>
    {
        private ICurrencyHistoryDbService service;
        private CurrencyHistoryEntity entity;

        [SetUp]
        public void SetUp()
        {
            service = ServiceBuilder<ChallengeDbContext, CurrencyHistoryEntity>.GetService<CurrencyHistoryDbService>();
            entity = CurrencyHistoryMock.CurrencyHistoryEntity();
        }

        [TestCase]
        public void InsertarCurrencyHistoryAsync()
        {
            service.InsertarCurrencyHistoryAsync(entity).Wait();

            Assert.Pass();
        }
    }
}
