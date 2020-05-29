#!/usr/bin/python
# -*- coding: utf-8 -*-

import os.path
import requests
from bs4 import BeautifulSoup
import datetime
import time

number = []
site = []
itemlink = []
itemname = []
price = []
url = 'https://algumon.com'
localpath = 'c:/tweet/'
filepath = localpath+'hotdeal.txt'
numberpath = localpath + 'hotdealnumber.txt'

def get_page():
    time.sleep(60)
    data = requests.get(url,allow_redirects= False)
    #data = urllib2.urlopen(url).read()
    sourcetext = data.text
    soup = BeautifulSoup(sourcetext, 'html.parser')
    return soup
def Get_info(soup):
    for item in soup.findAll("a", {"class": "product-link"}):
        number.append(item['data-product'])
        itemname.append(item['data-label'])
        itemlink.append(item['href'])
        #site.append(item.parent.parent.parent.contents[1].contents[3].text)
        site.append(item.parent.parent.parent.find("span", {"class":"label site"}).text)
        price.append(item.parent.parent.parent.parent.find("p", {"class": "deal-price-info"}).text.replace("\n", "").replace(" ", ""))

def TextFileWrite(path,content):
    txt = open(path, mode='w', encoding='utf-8')
    txt.write(content)
    txt.close()

def TextFileRead(path):
    textfile = open(path, mode='r', encoding='utf-8')
    line = textfile.readlines()
    textfile.close()
    return line[0]

while True:
    Get_info(get_page())

    for i in range(len(number)-1,-1,-1):
        time.sleep(3)
        if number[i] > TextFileRead(numberpath):
            TextFileWrite(numberpath, number[i])
            text = open(filepath, mode = 'a+t', encoding = 'utf-8')
            text.write('\n')
            text.write('&stf&')
            text.write('\n')
            text.write('[사이트] : ' + site[i] + '[번호] : '+ number[i])
            text.write('\n')
            text.write('[상품명] : ' + itemname[i])
            text.write('\n')
            text.write('[가격] : ' + price[i])
            text.write('\n')
            text.write('[링크] : ' + url + itemlink[i])
            text.write('\n')
            text.write('&eof&')
            text.write('\n')
            text.close()
            print('번호:'+number[i])
            print('사이트:'+site[i])
            print('이름:'+itemname[i])
            print('링크:'+url + itemlink[i])
            print('가격:'+price[i])

    time.sleep(300)


