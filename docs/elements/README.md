# Elements

New elements can be added in a number of different ways. The default way would normally be to add the element directly to the corresponding list - eg. the `MetaData` class exposes a `Links` collection for `<link>` elements, a `Meta` collection for `<meta>` elements and so forth.

The package however also features a number of extension methods that may help making your code easier to read and maintaing - eg. via a method chain when adding multiple elements.

## Link

Examples on how to add a new `<link>` element for a stylesheet - they all result in `<link rel="stylesheet" href="styles.css" />`:

```csharp
metaData.Links.Add(new Link("stylesheet", "styles.css"));

metaData.Links.Add(new Link(rel: "stylesheet", href: "styles.css"));

metaData.Links.Add("stylesheet", "styles.css"));

metaData.Links.Add(rel: "stylesheet", href: "styles.css"));

metaData.AddLink("stylesheet", "styles.css"));

metaData.AddLink(rel: "stylesheet", href: "styles.css"));
```

If you just specify two parameters without any explicing naming, the parameters are then `rel` and `href` respectively. If you use excplit naming, all parameters are optional and you may change the order of the parameters - eg.:

```csharp
metaData.AddLink(rel: "stylesheet", href: "styles.css", type: "text/css"));

metaData.AddLink(type: "text/css", rel: "stylesheet", href: "styles.css"));

metaData.AddLink(rel: "alternate", type: "application/rss+xml", href: "http://www.bjerner.dk/blog/rss"));
```

Changing the order of the parameters in C# does not affect the order of the attributes when converted to HTML.

The `<link>` element supports the following properties/parameters:

- **rel:** The value of the `rel` attribute.
- **href:** The value of the `href` attribute.
- **id:** The value of the `id` attribute.
- **type:** The value of the `type` attribute.
- **hid:** A unique Vue Meta identifier.

## Meta

`<meta>` elements are represented by the `Meta` class, and can be added to the `Meta` property of the `MetaData` class.

New elements may be added directly to the `Meta` collection of the `MetaData` class:

```csharp
var new MetData().Meta
    .Add(new Meta("viewport", "width=device-width, initial-scale=1"));
```

```
meta.AddMeta(new Meta
{
    Name = "viewport",
    Content = "width=device-width, initial-scale=1"
});
```

```csharp
var metaData = new MetData().Meta
    .Add(new Meta(charset: "utf-8"));
```

```csharp
var metaData = new MetData().Meta
    .Add(new Meta { Charset = "utf-8" });
```

Or via extension methods:

```csharp
var metaData = new MetData()
    .AddMeta(new Meta("viewport", "width=device-width, initial-scale=1"));
```

```csharp
var metaData = new MetData()
    .AddMeta("viewport", "width=device-width, initial-scale=1");
```

```csharp
var metaData = new MetData()
    .AddMeta(charset: "utf-8");
```