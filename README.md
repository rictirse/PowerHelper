# 程式發想
筆電的Tubro 在上網或文書時也在狂電，讓續航大失控，限制CPU最高使用率來降低功率跟溫度。

# 工作原理
![](https://i.imgur.com/8hLSOVm.png)

* 100%為不受限制，可以達到最高效能
* 99%不會開啟Tubro模式，可以大幅降低CPU電壓
* 文書處理的時候限制在50至60%約 2.2至2.4G
* 上網限制在 35%，CPU差不多在1.2GHz附近堪用，續航可以多好幾小時

![](https://i.imgur.com/Pw1IyDK.png)

# 程式須知
* 程式開啟後會常駐在右下角的電源符號
* 沒有關閉按鈕設計，結束需從工作管理員結束(taskkill /f /im powerHeloer.exe)
* 程式僅能開啟一次
* 沒有設計常駐功能，如果需要開機自動開啟，在shell:startup內建立捷徑
* 有些筆電已經有tune專用的電源管理，跟這個程式可能會衝突

![](https://i.imgur.com/zYKb0dR.png)

# 指令
powercfg 取得當前電源設置，AC(電源)/DC(電池)節能狀況 
```
powercfg /query SCHEME_CURRENT SUB_PROCESSOR
```

設定當前電源設置 DC(電池)模式下最高CPU使用率
```
powercfg -setdcvalueindex SCHEME_CURRENT SUB_PROCESSOR PROCTHROTTLEMAX value
```

設定當前電源設置 AC(電源)模式下最高CPU使用率
```
powercfg -setacvalueindex SCHEME_CURRENT SUB_PROCESSOR PROCTHROTTLEMAX value
```
