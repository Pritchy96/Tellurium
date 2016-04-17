﻿using System.Collections.Generic;
using System.Linq;
using MaintainableSelenium.Toolbox.Infrastructure;
using MaintainableSelenium.Toolbox.Screenshots.Domain;
using NHibernate.Linq;

namespace MaintainableSelenium.Toolbox.Screenshots.Queries
{
    public class FindPatternsForBrowserInCategory:IQueryAll<BrowserPattern>
    {
        private readonly long categoryId;
        private readonly string browserName;

        public FindPatternsForBrowserInCategory(long categoryId, string browserName)
        {
            this.categoryId = categoryId;
            this.browserName = browserName;
        }

        public List<BrowserPattern> GetQuery(IQueryable<BrowserPattern> query)
        {
            return query.Where(x => x.BrowserName == browserName && x.TestCase.Category.Id == categoryId)
                .Fetch(x=>x.BlindRegions)
                .Fetch(x=>x.PatternScreenshot)
                .ToList();
        }
    }
}