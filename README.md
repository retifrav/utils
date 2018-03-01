## My .NET Core utils

A set of console programs I create for my own workflow instead of learning Python.

* [google-photos-clickable-preview](#google-photos-clickable-preview)
* [forum-thread-downloader](#forum-thread-downloader)

### google-photos-clickable-preview

Takes a full URL of a Google Photos image and returns clickable preview, which you can use in your Octopress blog.

``` bash
[input]
dotnet gpcpreview.dll https://lh3.googleusercontent.com/some-photo=w3360-h1488-no
[output]
<a href="https://lh3.googleusercontent.com/some-photo=w3360-h1488-no" target="_blank">{% img center https://lh3.googleusercontent.com/some-photo=w700 Description %}</a>
```

Blog post: https://retifrav.github.io/blog/2017/02/01/google-photos-previews/

### forum-thread-downloader

Downloads the whole forum thread. Starts with the first page and recursively goes through thread pages, downloading each one. Merges all the pages into one long-ass page. Injects a `threadStyle.css` style.

No interface provided, you need to change the sources modifying the first link value with regular expressions and recompile the program.

Initialy was created for downloading threads from https://www.flyertalk.com/forum/.

Blog post: https://retifrav.github.io/blog/2018/01/22/csharp-dotnet-core-download-forum-thread/