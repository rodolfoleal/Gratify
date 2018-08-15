﻿
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace Gratify.Tests.Providers
{
    public class AsyncMockSetProvider
    {
        public static Mock<DbSet<T>> GenerateMockSet<T>(IList<T> mockData) where T : class
        {
            var data = mockData.AsQueryable();

            var mockSet = new Mock<DbSet<T>>();

            mockSet.As<IAsyncEnumerable<T>>()
                .Setup(m => m.GetEnumerator())
                .Returns(new TestAsyncEnumerator<T>(data.GetEnumerator()));

            mockSet.As<IQueryable<T>>()
                .Setup(m => m.Provider)
                .Returns(new TestAsyncQueryProvider<T>(data.Provider));

            mockSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

            return mockSet;
        }

    }
}
