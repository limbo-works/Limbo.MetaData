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