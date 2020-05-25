import tweepy
from tweepy import OAuthHandler, API
import datetime
import time
import os
import json
import urllib.request
import re
import os.path
import requests
import beautifulsoup

import bs4
from selenium import webdriver

localpath = 'C:/tweet/'
def papago(_str):
    options = webdriver.ChromeOptions()
    options.add_experimental_option('excludeSwitches', ['enable-logging'])
    options.add_argument('--log-level=3')

    driver = webdriver.Chrome(executable_path='C:\chromedriver.exe',options=options)
    #driver.implicitly_wait(3)
    #encText = urllib.parse.quote(_str)
    #data = "source=en&target=ko&text=" + encText
    url = "https://papago.naver.com/?sk=auto&tk=ko&hn=0&st="+_str
    driver.get(url)
    time.sleep(10)
    driver.implicitly_wait(10)
    html = driver.execute_script('return document.body.innerHTML')
    soup = bs4.BeautifulSoup(html, 'html.parser')
    team = str(soup.find("div", {"id": "txtTarget"}).find("span"))
    team = re.sub('<.+?>','',team,0).strip()
    driver.close()
    time.sleep(1)
    return team



CONSUMER_KEY = 
CONSUMER_SECRET = 
ACCESS_TOKEN = 
ACCESS_TOKEN_SECRET = 
auth = OAuthHandler(CONSUMER_KEY,CONSUMER_SECRET)
auth.set_access_token(ACCESS_TOKEN,ACCESS_TOKEN_SECRET)
api = API(auth)

#timetemp = datetime.datetime(2020, 4, 3, 5, 0, 0)
#varSubkey = "SOFTWARE\\WOW6432Node\\test"


while True :
    os.system('cls')
    #os.system('clear')
    print("tweet id              last tweet date / time")
    searched_tweets = []

    usernamefile = open(localpath+'tweetid.txt', mode='r', encoding='utf-8')
    lines = usernamefile.readlines()
    print("".join(lines).replace(" ","\t\t").replace("@ReadLiverpoolFC\t","@ReadLiverpoolFC").replace("@BSmith","@BSmith\t"))

    for userinfo in lines:
        try:
            time.sleep(1)
            user = userinfo.split()
            new_tweets = api.user_timeline(user[0])
            for Findtweet in new_tweets:
                if (((Findtweet.created_at + datetime.timedelta(hours=+9)) > (datetime.datetime.strptime(user[1]+' '+user[2], '%Y-%m-%d %H:%M:%S'))) & (Findtweet.retweeted == False) & (Findtweet.text[0:3] != 'RT ')):
                    searched_tweets.append(Findtweet)


        except tweepy.TweepError as e:
            filepath = localpath+'error.txt'
            if (os.path.isfile(filepath)) == False:
                text = open(filepath, mode = 'w')
                text.close()
            text = open(filepath, mode='a+t', encoding='utf-8')
            text.write('\n')
            text.write('&stf&')
            text.write('\n')
            text.write('수집 에러 :\n')
            text.write(tweepy.TweepError)
            text.write('\n')
            text.write('&eof&')
            text.write('\n')
            text.close()
            time.sleep(5)
            break
    usernamefile.close()

    name = []
    id = []
    mention = []
    result = []
    date = []
    twtime = []
    location = []
    origintime = []
    trans = []


    for tweet in searched_tweets:
        #result.append(tweet)
        created_time = str(tweet.created_at + datetime.timedelta(hours=+9))
        time_split = created_time.split()
        origintime.append(created_time)
        name.append(tweet.user.name)
        id.append('@' + tweet.user.screen_name)
        mention.append(tweet.text)
        trans.append(papago(str(tweet.text)))
        trans.append(tweet.text)
        date.append(time_split[0])
        twtime.append(time_split[1])
        location.append(tweet.user.location)

    #print(result)
    userfile = open(localpath+'tweetid.txt', mode='r', encoding='utf-8')
    lines2 = userfile.readlines()
    userlist_name = []
    userlist_time = []
    for userinfo in lines2:
        user = userinfo.split()
        userlist_name.append(user[0])
        userlist_time.append(user[1] + ' ' +user[2])
    userfile.close()
    for i in range(len(name)-1,-1,-1):
        for j in range(0, len(userlist_name)):
             if userlist_name[j] == id[i]:
                 #print(origintime[i])
                 userlist_time[j] = origintime[i]

        filepath = localpath+'tweet' + (date[i])[8:] + '.txt'
        if (os.path.isfile(filepath)) == False:
             text = open(filepath, mode = 'w')
             text.close()
        text = open(filepath, mode='a+t', encoding='utf-8')
        #print('닉네임:', name[i], ' - ', '내용 : ', mention[i], ' - ', '날짜 : ', date[i], ' - ', '시간 : ', time[i], ' - ', '위치 : ', location[i])
        text.write('\n')
        text.write('&stf&')
        text.write('\n')
        text.write('내용 :\n')
        text.write(mention[i].strip('\n'))
        text.write('\n')
        if mention[i] != trans[i]:
            text.write("번역 : \n")
            text.write(trans[i])
            text.write('\n')
        text.write('닉네임:')
        text.write(name[i])
        text.write('\n')
        text.write('날짜 : ')
        text.write(date[i])
        text.write(' ')
        text.write(twtime[i])
        text.write('\n')
        text.write('&eof&')
        text.write('\n')
        text.close()
        time.sleep(2)
    userfile = open(localpath+'tweetid.txt', mode='w+', encoding='utf-8')
    for j in range(0, len(userlist_name)):
        userfile.write(userlist_name[j])
        userfile.write(' ')
        userfile.write(userlist_time[j])
        userfile.write('\n')

    userfile.close()
    time.sleep(3)
