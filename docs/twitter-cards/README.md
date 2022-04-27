# Twitter Cards

Twitter supports multiple type of cards, so this package uses the `ITwitterCard` as a common type. Most common type is a summary card - which may be added like:

```csharp
MetaData metaData = new MetaData {
    Twitter = new TwitterSummaryCard {
        Creator = "@abjerner",
        Site = site.Name,
        Title = page.Name,
        Description = page.Teaser,
        Image = image?.Url
    }
};
```

Setting a `TwitterSummaryLargeImageCard` has the same properties, but results in a larger image when shared on Twitter:

```csharp
MetaData metaData = new MetaData {
    Twitter = new TwitterSummaryLargeImageCard {
        Creator = "@abjerner",
        Site = site.Name,
        Title = page.Name,
        Description = page.Teaser,
        Image = image?.Url
    }
};
```

The package also features a number of extension methods for setting the Twitter Card - eg. to set a new `TwitterSummaryCard`:

```csharp
MetaData metaData = new MetaData()
    .SetTwitterCard((TwitterSummaryCard tw) => {
        tw.Creator = "@abjerner";
        tw.Site = site.Name;
        tw.Title = page.Name;
        tw.Description = page.Teaser;
        tw.Image = image?.Url;
    });
```

or to set a new `TwitterSummaryLargeImageCard`:

```csharp
MetaData metaData = new MetaData()
    .SetTwitterCard((TwitterSummaryLargeImageCard tw) => {
        tw.Creator = "@abjerner";
        tw.Site = site.Name;
        tw.Title = page.Name;
        tw.Description = page.Teaser;
        tw.Image = image?.Url;
    });
```