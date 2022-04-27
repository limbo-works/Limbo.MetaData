# Open Graph

The Open Graph of a given page is represented by the `OpenGraphProperties` class:

```csharp
MetaData metaData = new MetaData {
    OpenGraph = new OpengraphProperties {
        CanonicalUrl = canonicalUrl,
        SiteName = root.Name,
        Title = Model.Name,
        Description = teaser
    }
};

if (image != null) {
    metaData.OpenGraph.AppendImage(image.Url, 1200, 630);
}
```

```csharp
MetaData metaData = new MetaData()
    .SetOpenGraph(og => {
        og.Url = canonicalUrl;
        og.SiteName = root.Name;
        og.Title = Model.Name;
        og.Description = teaser;
        if (image != null) og.AppendImage(image.Media.GetCropUrl(width: 1200, height: 630, urlMode: UrlMode.Absolute), 1200, 630);
    });
```