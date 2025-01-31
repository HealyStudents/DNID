import streamlit as st
import matplotlib.pyplot as plt
import pandas as pd

st.write("""
# Style in Streamlit

## Markdown

Streamlit uses markdown to dictate its text style. It's the same language used in GitHub README files, text blocks in Jupyter Notebooks, and Discord (though discord's is simplified a bit).

In this section, I'll give examples of everything you can do in markdown.

### Headings

Headings are created using the `#` at the start of the line. Adding extra `#` will make the heading a smaller heading (for example, `#` would indicate the title of the document while `##` is a section heading and `###` a subheading).

### Formatting text

We can make *text italicized* by surrounding text with a single `*`, **make it bold** with `**`, or ***do both*** with `***`.

As I've been doing throughout this doc so far, you can `format text to look like code` using the \`. If you use three in a row, you can make a whole code block and even specify the language for syntax highlighting:

```java
public class Hello{
	public static void main(String[] args){
		System.out.println("Hello World!");
	}
}
```

Let's say we wanted to add a quote to our doc. We can format this in blockquote style using `>`

> "Blockquotes are neat"
>
> Walt Whitman

As might be especially useful when doing math stuff, we can wrap things in `$` to open up a LaTeX-style symbollic syntax. For example, $x^2$ or $x_2$ or $\sqrt{10x}$. This additional symbollic language we're using inside `$` is typically called **"inline math"**. It's hard to find centralized documentation on it, but [here's some documentation GitHub made for its own markdown support](https://docs.github.com/en/get-started/writing-on-github/working-with-advanced-formatting/writing-mathematical-expressions), streamlit's support is very similar.

Notice how I made a link ^^^^^. That's how you do that!

We can ~~strikethrough text~~ with `~`.

### Lists

We can make a few different kinds of lists. 

- Here is 
- an unordered
- list

1. We can
2. also do
3. numbered lists

- [x] Or we can
- [ ] format our list
- [ ] as if it's a to-do list

### Images

We can include images using a pretty similar syntax to including a link. This adds a photo hosted elsewhere on the internet (this one's the streamlit logo):

![This is where we write alt text. This is the streamlit logo.]( https://streamlit.io/images/brand/streamlit-logo-primary-colormark-darktext.png)

If I use the st method `st.image`, I can add the photo that's in this file's folder:
""")

st.image("blastoise.png")

st.write("""
### Footnotes

Often, like when we're ***citing something***, we should use footnotes [^1]. This will add a footnote list to the bottom of this markdown block.

[^1]: Here's that footnote.

### Misc Stuff

You can add emojis! :pensive:

You can add horizontal lines to break up sections:

---

## Themes

You may have noticed that this file looks a little different in basic style than a lot of other streamlit docs you've encountered. This is because it has a theme configured! Check out the `./.streamlit/config.toml` file, which defines this style! You can find more info on this [in this documentation](https://blog.streamlit.io/introducing-theming/).

We can also add explicit css (or javascript!) to the page with the `st.markdown` method.

""")

st.markdown("""<style>
	a:link {
	  background-color: grey;
	}

	a:visited {
	  background-color: black;
	}

	a:hover {
	  background-color: lightgreen;
	}

	a:active {
	  background-color: hotpink;
	} 
	</style>""", unsafe_allow_html=True)



