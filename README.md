# Windows 10 / 11 節能調整
調整處理器電源管理中的最高處理器狀態降低功率，延長筆電續航/桌機溫度與耗電表現
![](https://i.imgur.com/8hLSOVm.png)

* 100%為不受限制，可以達到最高效能
* 99%不會開啟Tubro模式
* 更低則會限制CPU最高使用率，UI後面的時脈僅共參考
![](https://i.imgur.com/Pw1IyDK.png)


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
