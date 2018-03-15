# LogicoolHandleUtility
Logicoolのハンドルコントローラのユーティリティ。(動作確認G29)<br>
ハンコンのSDKをUnityから利用できるようにしました。
## 内容物
Handle.dll
HandleUtility.cs
## 使い方
Handl.dllとHandleUtility.csをプロジェクトにインポート(ドラッグ&ドロップ)
HandleUtilityのメンバを呼び出して使用する。

## 説明

### void Initialize()
ハンドルを使用する前に必ず呼び出す。

### void ShatdownSteering()
ハンドルの使用を終了する際に呼び出す。

### int GetHandle()
ハンドルの値を返す。右に回すと正、左に回すと負の値。値の幅は-32768~32767

### int GetAccel()
アクセル(一番右のペダル)の値を返す。踏み込むと負、離すと正。値の幅は
-32768~32767

### int GetBrake()
ブレーキ(真ん中のペダル)の値を返す。踏み込むと負、離すと正。値の幅は
-32768~32767

### int GetClutch ()
クラッチ(一番左のペダル)の値を返す。踏み込むと負、離すと正。値の幅は
-32768~32767

### bool GetButton(int buttonId)
buttonIdのボタンの押し込み状態を取得
buttonIdは以下の通り
#### BUTTON_CROSS
バツボタン
#### BUTTON_SQUARE
四角ボタン
#### BUTTON_CIRCLE
丸ボタン
#### BUTTON_TRIANGLE
四角ボタン
#### BUTTON_BACK_RIGHT
パドルシフト。右側。
#### BUTTON_BACK_LEFT
パドルシフト。左側。
#### BUTTON_R2
R2
#### BUTTON_L2
L2
#### BUTTON_SHARE
SHAREボタン
#### BUTTON_OPTION
OPTIONボタン
#### BUTTON_R3
R3
#### BUTTON_L3
L3
#### BUTTON_PLUS
+ボタン
#### BUTTON_MINUS
-ボタン
#### BUTTON_RED_DIAL_RIGHT
赤いダイアルを右に回す。
#### BUTTON_RED_DIAL_LEFT
赤いダイアルを左に回す。
#### BUTTON_RETURN
Enter?矢印のボタン
#### BUTTON_PS
PSボタン。

### int GetPOV()
十字キーの状態を取得。以下の値が返ってくる。
#### POV_UP
上
#### POV_RIGHT_UP
右上
#### POV_RIGHT
右
#### POV_RIGHT_DOWN
右下
#### POV_DOWN
下
#### POV_LEFT_DOWN
左下
#### POV_LEFT
左
#### POV_LEFT_UP
左上

### bool Spring(int offset, int saturationPercentage, int coefficientPercentage)
ハンドルの復元力を指定する関数。
#### offset
戻ってくる位置を入れる。-100~100の間。(通常0)
#### saturationPercentage
どれぐらいの勢いで戻ってくるか。0~100の間の値を入れる。この範囲にない値は0または100になる。
#### coefficientPercentage
回した角度に対して復元力がどれだけ強くなるか。通常、復元力はハンドルを切れば切るほど強くなるものでそれがどの程度の割合で増加していくのかという値。-100~100の間の値を入れる。この範囲にない値は-100または100になる。

### bool StopSpring()
ハンドルの復元力を無効化する。

### bool ConstantForce(int power)
路面から恒常的に受ける力を表す。物理エンジンと紐づけて連続的に毎フレーム値を受け取るといい。正面タイヤが側方から受ける力を元に算出すると良く、停止しているときや滑らかな路面をまっすぐ走っているときには0にしておき、曲がるときや凸凹した道路を走るときに何らかの値を与える。(多分)値の範囲は-100から100。はみ出た分は-100か100になる。

### bool StopConstantForce()
恒常的な力を無効化。

### Damper(int power)
泥やぬかるみなどハンドルがとられる場所や凍結した路面などすべりやすい場所で働く力を及ぼす。-100から100の間で小さくなるほどすべり、大きくなるほど動かしにくくなる。

### bool StopDamper()
Damperを無効化する。

### bool SideCollision(int power)
横からの衝突の際に受ける力。-100から100の間の値。負の値は衝突方向を反転させる。

### bool FrontalCollision(int power)
正面衝突の際に受ける力。0から100の間の値。

### bool DirtRoadEffect(int power)
ダート走行の際のシミュレート。0から100の間の値。

### bool StopDirtRoadEffect(int power)
ダート走行の終了。

### bool BumpyRoadEffect(int power)
凸凹した道を走行する際のシミュレート。0から100の間の値。

### bool StopBumpyRoadEffect()
凸凹走行の終了。

### bool SlipperyRoadEffect(int power)
スリップした際のシミュレート。0から100の間の値。

### bool StopSlipperyRoadEffect()
スリップの終了。

### bool CarAirborneEffect()
前輪が浮いちゃってる状態。

### bool StopCarAirborneEffect()
前輪の浮きを解消。

### bool SoftstopForce(int range)
謎。

### bool StopSoftstopForce()
SoftstopForceの影響を無効化する。

### bool PlaySurfaceEffect(int type, int magnitudePercentage, int peiod)
路面から伝わる力をシミュレートする。
#### type
路面凹凸の形状。以下の値から選ぶ
##### ・PERIODICTYPE_SINE
滑らかな凸凹。
##### ・PERIODICTYPE_TRIANGLE
三角形
##### ・PERIODICTYPE_SQUARE
四角形

#### magnitudePercentage
受ける力の強さ。0から100の間の値。

#### period
力を受ける頻度。小さいほどより頻繁に力を受ける。単位はms
砂利道なら20ぐらい、木の橋とか石畳なら120ぐらい。150は超えないほうがいい。

### bool StopSurfaceEffect()
路面から伝わる力を無効化。

### int GetNonLinearValue(int nonLinCoeff, int inputValue)
inputValueに与えられた値を-32768~32767の範囲で非線形に補完して返す関数。
そもそもこのハンドルコントローラは1回転と4分の1までしか回転しない。
普通の車は3~4回転ぐらいするのでそのままハンドルからの入力を線形に現実の車のハンドルの回転範囲に当てはめてしまうと感度が倍近くなり、操作が難しい。
そこでハンドルのニュートラル付近では感度を低く、切っていくにつれて高感度にするように非線形に補完するとよく、そのために使う関数。
#### nonLinCoeff
変換の仕方。-100~100の間の値を入れる。0では完全に線形。正の値で中央付近で鈍感、切ると敏感になる。負の値は逆に中央付近で敏感、切ると鈍感になる。
#### inputValue
ハンドルからの入力。

### bool HasForceFeedback()
今フォースフィードバックが使えるか。

### bool IsPlaying(int forceType)
今forceTypeに指定した力が働いているか。以下の値を入れる。
#### FORCE_SPRING
#### FORCE_CONSTANT
#### FORCE_DAMPER
#### FORCE_SIDE_COLLISION
#### FORCE_FRONTAL_COLLISION
#### FORCE_DIRT_ROAD
#### FORCE_BUMPY_ROAD
#### FORCE_SURFACE_EFFECT
#### FORCE_CAR_AIRBORNE
#### FORCE_SODT_STOP
#### FORCE_NONE

### bool IsConnected()
ハンドルが接続されているかどうか

### int GetShiftMode()
シフトレバーの種類を取得する関数。
1ならゲーテッド、0ならシーケンシャル、-1なら不明。


### bool SetOperatingRange(int range)
ハンドルの回転角を制御する。
#### range
最大角。これ以上回らなくなる。

### bool PlayLEDs(float currentRPM, float rpmFirstLedTurnsOn, float rpmRedLine)
PSマークの上のLEDを光らせる。
#### currentRPM
点灯するLED。大きい値ほど中央のLEDが光る。
#### rpmFirstLedTurnsOn
最初につくLED。大きい値ほど中央のLEDが最初っから光る。
#### rpmRedLine
LEDが光り始める閾値。

