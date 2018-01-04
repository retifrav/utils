## My .NET Core utils

A set of console programs I create for my own workflow instead of learning Python.

* [google-photos-clickable-preview](#google-photos-clickable-preview)

### google-photos-clickable-preview

Takes a full URL of a Google Photos image and returns clickable preview, which you can use in your Octopress blog.

``` bash
[input]
dotnet gpcpreview.dll https://lh3.googleusercontent.com/some-photo=w3360-h1488-no
[output]
<a href="https://lh3.googleusercontent.com/some-photo=w3360-h1488-no" target="_blank">{% img center https://lh3.googleusercontent.com/some-photo=w700 Description %}</a>
```