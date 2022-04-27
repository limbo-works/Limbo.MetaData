# Open Graph

The Open Graph information of a given page is represented by the `OpenGraphProperties` class. You can se the `OpenGraph` property on `MetaData` directly:

```csharp
MetaData metaData = new MetaData {
    OpenGraph = new OpengraphProperties {
        CanonicalUrl = canonicalUrl,
        SiteName = site.Name,
        Title = page.Name,
        Description = page.Teaser
    }
};

if (image != null) {
    metaData.OpenGraph.AppendImage(image.Url, 1200, 630);
}
```

Or set it via an extension method:

```csharp
MetaData metaData = new MetaData()
    .SetOpenGraph(og => {
        og.Url = canonicalUrl;
        og.SiteName = site.Name;
        og.Title = page.Name;
        og.Description = page.Teaser;
        if (image != null) og.AppendImage(image.Url, 1200, 630);
    });
```

```csharp
MetaData metaData = new MetaData()
    .SetOpenGraph(new OpengraphProperties {
        CanonicalUrl = canonicalUrl,
        SiteName = site.Name,
        Title = page.Name,
        Description = page.Teaser
    });
```