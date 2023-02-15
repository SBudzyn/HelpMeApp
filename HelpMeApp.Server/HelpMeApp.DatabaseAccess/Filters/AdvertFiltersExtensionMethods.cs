using HelpMeApp.DatabaseAccess.Entities.AdvertEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpMeApp.DatabaseAccess.FiltersExtensionMethods
{
    public static class AdvertFiltersExtensionMethods
    {
        public static IQueryable<Advert> FilterByHelpType(this IQueryable<Advert> query, int helpTypeId)
        {
            if (helpTypeId != 0)
            {
                return query.Where(a => a.HelpTypeId == helpTypeId);
            }

            return query;
        }

        public static IQueryable<Advert> FilterByCategory(this IQueryable<Advert> query, int categoryId)
        {
            if (categoryId != 0)
            {
                return query.Where(a => a.CategoryId == categoryId);
            }

            return query;
        }

        public static IQueryable<Advert> FilterByLocation(this IQueryable<Advert> query, string location)
        {
            if (location != null)
            {
                return query.Where(a => a.Location == location);
            }

            return query;
        }

        public static IQueryable<Advert> FilterByTerms(this IQueryable<Advert> query, int termsId)
        {
            if (termsId != 0)
            {
                return query.Where(a => a.TermsId == termsId);
            }

            return query;
        }

        public static IQueryable<Advert> Sort(this IQueryable<Advert> query, string orderBy)
        {
            if (orderBy == "date")
            {
                return query.OrderByDescending(a => a.CreationDate);
            }
            else
            {
                return query.OrderBy(a => a.Id);
            }
        }
    }
}
