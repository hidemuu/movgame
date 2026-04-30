# AGENTS.md

このリポジトリで修正作業を行うエージェント向けの作業メモです。まずこのファイルを読み、既存の構成と検証方法に合わせて小さく安全に変更してください。

## リポジトリ概要

- `app/movgame.Wpf`: WPF アプリケーションの起動プロジェクトです。通常のデスクトップ版修正はここから参照関係を追います。
- `app/movgame.Web`: ASP.NET Core + React の Web アプリケーションです。
- `app/movgame`: コンソールアプリケーションです。
- `src/domains/movgame.Models`: ゲームエンジン、マップ、キャラクターなどのドメインロジックです。
- `src/applications/movgame.Service`: ゲームループ、描画、リポジトリ利用などのアプリケーションサービスです。
- `src/applications/movgame.Repository`: リポジトリインターフェースとインメモリ実装です。
- `src/presentations/movgame.Wpf.Views`: WPF の View です。
- `src/presentations/movgame.Wpf.ViewModels`: WPF の ViewModel と WPF 用サービスです。
- `src/presentations/movgame.Wpf.Models`: WPF 用の定数やモデルです。
- `src/infrastructures/*`: WPF コントロール、デザイン、ユーティリティなどのインフラ層です。

## よく触る場所

- ゲーム進行のループ: `src/applications/movgame.Service/GameServiceBase.cs`
- WPF 画面更新: `src/presentations/movgame.Wpf.ViewModels/GameViewModel.cs`
- WPF 描画サービス: `src/presentations/movgame.Wpf.ViewModels/Services/GameService.cs`
- ゲーム状態と衝突判定: `src/domains/movgame.Models/GameEngine.cs`
- プレイヤー移動: `src/domains/movgame.Models/Characters/Player.cs`
- 敵移動: `src/domains/movgame.Models/Characters/Alien.cs`, `BreadAlien.cs`
- マップ生成: `src/domains/movgame.Models/Maps/GameMap.cs`

## 作業方針

- 既存のレイヤー分けを保ってください。ゲームルールは原則 `movgame.Models`、ゲームループや描画フローは `movgame.Service` / WPF ViewModel 側に置きます。
- WPF の見た目だけの変更とゲームロジックの変更を混ぜすぎないでください。
- 既存の日本語コメントがあるファイルでは、コメントを追加する場合も簡潔な日本語で統一してください。
- `bin/` と `obj/` は生成物です。通常は編集しないでください。
- `docs/機能一覧表.xlsx` は仕様資料の可能性があります。必要な場合だけ確認してください。
- 作業ツリーに自分が触っていない変更がある場合は、勝手に戻さず共存してください。

## 検索

PowerShell 環境です。`rg` が使える場合は優先してください。使えない場合は以下で代替できます。

```powershell
Get-ChildItem -Recurse -Include *.cs,*.xaml -File | Select-String -Pattern "検索語"
```

## ローカル Skills

- `.codex/skills/bug-fix`: バグ調査と修正用です。WPF、ゲームループ、衝突判定、キャラクター移動などの不具合修正で使ってください。

## ビルドと検証

このリポジトリでは `movgame.sln` に存在しないプロジェクト GUID の参照が残っている場合があります。ソリューション全体のビルドが失敗する時は、修正対象のプロジェクト単体で確認してください。

.NET CLI がホームディレクトリへ初回設定を書こうとして失敗する環境では、ワークスペース内に `DOTNET_CLI_HOME` を向けてください。

```powershell
$env:DOTNET_CLI_HOME="$PWD\.dotnet-home"
$env:DOTNET_SKIP_FIRST_TIME_EXPERIENCE="1"
dotnet build src\domains\movgame.Models\movgame.Models.csproj --no-restore
dotnet build app\movgame.Wpf\movgame.Wpf.csproj --no-restore
```

検証後に `.dotnet-home/` が未追跡で残った場合は削除してください。

## 既知の注意点

- `src/domains/movgame.Models/movgame.Models.csproj` は `System.Drawing.Common` 5.0.2 を参照しており、脆弱性警告が出る場合があります。警告の扱いを変更する時は影響範囲を確認してください。
- WPF 起動プロジェクトのターゲットフレームワークは変更される可能性があります。ビルド失敗時は `app/movgame.Wpf/movgame.Wpf.csproj` の `TargetFramework` を確認してください。
- 衝突判定は `GameEngine.GetCollision(...)` に集約されています。プレイヤー側と敵側の移動処理で同じ判定をどう扱うかに注意してください。
- 敵 AI は `Alien.NextMoveRandom()`, `Alien.MoveExec()`, `BreadAlien.NextMoveBread()` に分かれています。追跡挙動の変更は `BreadAlien` も確認してください。

## 修正後チェックリスト

- 変更したレイヤーに近いプロジェクトをビルドしたか。
- WPF 挙動を変えた場合、`app/movgame.Wpf` までビルド確認したか。
- ゲームロジックを変えた場合、プレイヤー移動時と敵移動時の両方で破綻しないか確認したか。
- 生成物や一時ディレクトリをコミット対象に含めていないか。
