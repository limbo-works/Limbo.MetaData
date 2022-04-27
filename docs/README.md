# Documentation

The purpose of this package is to allow developers easily managing meta data of HTML based pages. As such, the package provides a number of classes and user friendly extension methods.

## Getting Started

The package revolves around the `MetaData` class - or optionally the `VueMetaData` class if you're targeting Vue Meta specifically.

Initializing a new `MetaData` instance doesn't really do much on it's own, but may be done as:

```csharp
// Initialize a new instance
MetaData metaData = new MetaData();
```

The `VueMetaData` class extends `MetaData`, and provides some additional features - and allows serializing an instance to a JSON format supported by Vue Meta.

You may initialize it the same way as `MetaData`:

```csharp
// Initialize a new instance
VueMetaData metaData = new VueMetaData();
```

Or optionally pass on a `CultureInfo` to the constructor:

```csharp
// Initialize a new instance
VueMetaData metaData = new VueMetaData(CultureInfo.CurrentCulture);
```

`VueMetaData` instances have a `HtmlAttributes` property, which is of the type `HtmlAttributeList`. This class then has a `Language` property, which corresponds to the `lang` attribute on the page's `<html>` element. Specifying a culture for the constructor will automatically set the `Language` property to the name of the culture - eg. `en-US` or `da-DK`.

## Special Elements

The `MetaData` class handles a number of different `<link>` and `<meta>` elements, meaning that these won't be part of the `MetaData.Links` or `MetaData.Meta` collections.

These elements are as following:

### Canonical URL

The `MetaData` class exposes a `CanonicalUrl` property, and if specified, will result in a `<link>` element like this:

```html
<link rel="canonical" href="https://www.limbo.works/" />
```

You can set the property directly like this:

```csharp
MetaData meta = new MetaData() {
    CanonicalUrl = "https://www.limbo.works/"
};
```

Or alternatively via the `SetCanonicalUrl` extension method - eg. as part of a method chain:


```csharp
MetaData meta = new MetaData()
    .SetCanonicalUrl("https://www.limbo.works/")
    .SetRobots("index,follow");
```

### Browser Title

```csharp
MetaData meta = new MetaData() {
    Title = "You're in Limbo"
};
```

or:

```csharp
MetaData meta = new MetaData()
    .SetTitle("You're in Limbo");
```

### Robots

```csharp
MetaData meta = new MetaData() {
    Robots = "index,follow"
};
```

or:

```csharp
MetaData meta = new MetaData()
    .SetRobots("index,follow");
```

### Open Graph

- [Read more about Open Graph](./open-graph/)

### Twitter Cards

- [Read more about Twitter Cards](./twitter-cards/)