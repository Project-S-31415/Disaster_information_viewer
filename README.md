# Disaster_information_viewer
2022 02/10開発開始

一つにまとめたかった（？）
#### やっぱり分けるので開発終了



## 現在v1.0.0
### 強震モニタ
リアルタイム震度と長周期地震動、振動レベル、地点震度

### EEW
NIED、iedred(2つで1req/3s)

地点震度、震央距離(計算が合っているかは不明)

到達時間計算用にログ出力機能付き

iedredから警報地域表示＆TwitterBot機能付き

### 地震履歴
P2P APIから10件(震度速報、震源情報含む)←改良予定

## ↓予定
### 津波情報
P2P APIから　地図、リスト（5件）
デシリアライズがうまくできない＆画像表示が面倒

### デザイン
EEWの背景を画像に　地震履歴の画像編集

### USGS,Hi-net
地震履歴のところに入れる予定(Hi-netは検討中)

### 他
NIED取得を2秒前に

# v1.0
開発約1か月記念。

