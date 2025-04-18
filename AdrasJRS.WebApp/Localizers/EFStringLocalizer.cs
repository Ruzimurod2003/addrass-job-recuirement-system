﻿using AdrasJRS.Data.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using System.Globalization;

namespace AdrasJRS.Localizers;

public class EFStringLocalizer : IStringLocalizer
{
    private readonly DataDbContext _db;

    public EFStringLocalizer(DataDbContext db)
    {
        _db = db;
    }

    public LocalizedString this[string name]
    {
        get
        {
            var value = GetString(name);
            return new LocalizedString(name, value ?? name, resourceNotFound: value == null);
        }
    }

    public LocalizedString this[string name, params object[] arguments]
    {
        get
        {
            var format = GetString(name);
            var value = string.Format(format ?? name, arguments);
            return new LocalizedString(name, value, resourceNotFound: format == null);
        }
    }

    public IStringLocalizer WithCulture(CultureInfo culture)
    {
        CultureInfo.DefaultThreadCurrentCulture = culture;
        return new EFStringLocalizer(_db);
    }

    public IEnumerable<LocalizedString> GetAllStrings(bool includeAncestorCultures)
    {
        return _db.Resources
            .Include(r => r.Culture)
            .Where(r => r.Culture.Name == CultureInfo.CurrentCulture.Name)
            .Select(r => new LocalizedString(r.Key, r.Value));
    }

    private string GetString(string name)
    {
        return _db.Resources
            .Include(r => r.Culture)
            .Where(r => r.Culture.Name == CultureInfo.CurrentCulture.Name)
            .FirstOrDefault(r => r.Key == name)?.Value;
    }
}