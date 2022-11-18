import pandas as pd
import requests
import sys

def barForTK():
    df = pd.read_csv('https://raw.githubusercontent.com/andrzejmp/some_codes/main/python/tourism/data.csv')

    year = df["YEAR"]
    tk = df[" TK"]

    import matplotlib.pyplot as plt

    plt.bar(year,tk)
    plt.title('Tourism Income of Turkey')
    plt.xlabel('Year')
    plt.ylabel('Income')
    plt.show()
    
barForTK()