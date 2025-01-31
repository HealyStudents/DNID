import streamlit as st
import matplotlib.pyplot as plt
import pandas as pd
from bokeh.plotting import figure, show
import numpy as np

st.write("""
# Using Bokeh in Streamlit

Bokeh is an extremely useful package for making interactive plots, and you can insert bokeh plots into streamlit docs!

There is one major quirk with streamlit bokeh is it only supports ***bokeh 2*** and not the (current) ***bokeh 3***. If you have the more recent bokeh installed, when you try to run this file, streamlit will give an error message with the exact pip command you should run to fix the issue.
""")

#Generate a bunch of dummy data
N = 4000
x = np.random.random(size=N) * 100
y = np.random.random(size=N) * 100
radii = np.random.random(size=N) * 1.5
colors = np.array([(r, g, 150) for r, g in zip(50+2*x, 30+2*y)], dtype="uint8")

#define which tools we want to include
TOOLS="hover,crosshair,pan,wheel_zoom,zoom_in,zoom_out,box_zoom,undo,redo,reset,tap,save,box_select,poly_select,lasso_select,help"

#define the figure (kinda like in matplotlib)
p = figure(tools=TOOLS)

#a kind of scatterplot: plotting circles
p.circle(x, y, radius=radii,
         fill_color=colors, fill_alpha=0.6,
         line_color=None)

st.bokeh_chart(p)