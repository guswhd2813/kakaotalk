import time
from selenium import webdriver
from selenium.webdriver.chrome.service import Service
from selenium.webdriver.chrome.options import Options
from selenium.webdriver.common.by import By
from selenium.webdriver.common.action_chains import ActionChains
from webdriver_manager.chrome import ChromeDriverManager
from selenium.webdriver.support.ui import WebDriverWait
from selenium.webdriver.support import expected_conditions as EC
from selenium.webdriver.common.keys import Keys


# 스크롤을 반복하면서 페이지 끝까지 내리기
def scroll_to_bottom(driver):
    last_height = driver.execute_script("return document.body.scrollHeight")  # 페이지의 현재 높이

    while True:
        driver.execute_script("window.scrollTo(0, document.body.scrollHeight);")  # 페이지 끝까지 스크롤
        time.sleep(2)  # 페이지 로드 시간 기다림

        # 새 페이지 높이 확인
        new_height = driver.execute_script("return document.body.scrollHeight")

        # 새 높이가 이전 높이와 같다면, 끝까지 스크롤한 것
        if new_height == last_height:
            break
        last_height = new_height  # 새 높이로 갱신

# 웹 드라이버 설정
options = Options()
options.add_argument("--disable-extensions")
driver = webdriver.Chrome(service=Service(ChromeDriverManager().install()), options=options)

# 로그인 후 네이버 지도 페이지로 이동
login_url = "https://nid.naver.com/nidlogin.login"  # 네이버 로그인 페이지 URL
protected_url = "https://map.naver.com/"  # 네이버 지도 페이지 URL

# 로그인 페이지 열기
driver.get(login_url)

# 사용자에게 로그인 후 Enter를 눌러달라고 안내
input("로그인 후 Enter 키를 눌러주세요...")  # 수동으로 로그인 후 인증이 완료되면 Enter 키를 눌러 쿠키 저장

# 로그인 후 네이버 지도 페이지로 이동
driver.get(protected_url)

# 페이지 로드 대기
time.sleep(5)

# 첫 번째 버튼 클릭 (xpath: /html/body/div[1]/div/header/nav/ul/li[6]/button)
button_1 = driver.find_element(By.XPATH, "/html/body/div[1]/div/header/nav/ul/li[6]/button")
button_1.click()

# 페이지 로드 대기
time.sleep(3)  # 버튼 클릭 후 페이지 변화가 있을 수 있으므로 충분한 대기

# 특정 iframe으로 전환
iframe_xpath = "/html/body/div[1]/div/div[2]/div[1]/div/div/div[1]/div/div[2]/div/iframe"
iframe = driver.find_element(By.XPATH, iframe_xpath)
#/html/body/div[1]/div/div[2]/div[1]/div/div/div[1]/div/div[2]/div/iframe
#/html/body/div[1]/div/div[2]/div[1]/div/div/div[1]/div/iframe

# 해당 iframe으로 전환
driver.switch_to.frame(iframe)

# 두 번째 버튼 클릭 (iframe 내에서)
button_2_xpath = "//*[@id='app']/div/div/ul/li[2]/button/div[2]/div[1]"  # 두 번째 버튼 XPath
button_2 = driver.find_element(By.XPATH, button_2_xpath)
button_2.click()

# 페이지 로드 대기
time.sleep(5)  # 두 번째 버튼 클릭 후 페이지 변화 대기

# 두 번째 iframe을 찾기 위한 XPath 정의
#iframe_xpath2 = "//iframe[@id='myPlaceBookmarkListIframe']"  # id 속성을 이용하여 두 번째 iframe을 찾음

try:
    iframe = driver.execute_script("return document.getElementById('myPlaceBookmarkListIframe');")
    if iframe:
        driver.switch_to.frame(iframe)
        print("두 번째 iframe으로 전환 성공")
        scroll_to_bottom(driver)
        print("스크롤성공")
    else:
        print("iframe을 찾지 못했습니다.")
except Exception as e:
    print(f"JavaScript 실행 중 오류 발생: {e}")





li_elements = driver.find_elements(By.XPATH, "/html/body/div[1]/div/div[3]/div/ul/li")



if li_elements:
    for index, li in enumerate(li_elements, start=1):
        try:
            A = li.find_element(By.XPATH, "./div[1]/div[1]/strong").text
            B = li.find_element(By.XPATH, "./div[1]/div[1]/span").text
            C = li.find_element(By.XPATH, "./div[1]/div[2]/span").text
            print(f"Item {index} -> Title: {A}, category: {B}, Address: {C}")
        except Exception as e:
            print(f"Item {index}에서 오류 발생: {e}")
else:
    print("li_elements가 비어있습니다.")

#driver.switch_to.default_content()

#driver.quit()
