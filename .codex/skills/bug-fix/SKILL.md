---
name: bug-fix
description: Diagnose and fix Movgame defects safely. Use when Codex is asked to investigate a bug, reproduce broken behavior, repair WPF/gameplay/domain/service issues, fix regressions, resolve crashes, or make a targeted corrective code change with verification.
---

# Bug Fix

## Workflow

1. Read project context first.
   - Read `AGENTS.md` for current repository layout, common files, build notes, and known pitfalls.
   - Check `git status --short` before editing.
   - Treat unrelated dirty files as user work; do not revert them.

2. Define the failing behavior.
   - Restate the expected behavior and the actual behavior.
   - Locate the likely layer: WPF view/viewmodel, application service loop, domain game engine, character logic, map generation, repository, or Web app.
   - Prefer a narrow reproduction path over broad refactoring.

3. Trace cause before changing code.
   - Read call sites and nearby code around the failing behavior.
   - For gameplay bugs, inspect both player-driven and enemy/game-loop-driven paths.
   - For WPF bugs, inspect binding, command, ViewModel state, service callbacks, and threading assumptions.
   - For collision, movement, score, life, and clear/game-over bugs, inspect `GameEngine`, `GameServiceBase`, `Player`, `Alien`, and `BreadAlien` together.

4. Implement the smallest complete fix.
   - Keep game rules in `src/domains/movgame.Models` unless the bug is specifically UI or orchestration.
   - Keep loop, drawing, and service lifecycle fixes in `src/applications/movgame.Service` or WPF ViewModel services.
   - Avoid changing generated `bin/` or `obj/` files.
   - Preserve existing Japanese comments and naming style.

5. Verify close to the changed layer.
   - For domain/gameplay changes, build `src\domains\movgame.Models\movgame.Models.csproj`.
   - For WPF behavior changes, build `app\movgame.Wpf\movgame.Wpf.csproj` when the environment supports it.
   - If `movgame.sln` fails because of existing solution GUID issues, do not treat that as a new bug; run targeted project builds instead.
   - If `.NET` first-run setup fails, set `DOTNET_CLI_HOME` inside the workspace as documented in `AGENTS.md`.

6. Clean up and report.
   - Remove temporary verification directories such as `.dotnet-home/`.
   - Summarize the root cause, changed files, and verification commands.
   - State any blocked verification clearly.

## Movgame Defaults

- WPF entry point: `app/movgame.Wpf`.
- Main game loop and game-over checks: `src/applications/movgame.Service/GameServiceBase.cs`.
- Game state and collision: `src/domains/movgame.Models/GameEngine.cs`.
- Player movement and damage: `src/domains/movgame.Models/Characters/Player.cs`.
- Enemy movement and chase behavior: `src/domains/movgame.Models/Characters/Alien.cs` and `BreadAlien.cs`.
- WPF image refresh and dialogs: `src/presentations/movgame.Wpf.ViewModels/GameViewModel.cs`.

## Reference

Read `references/bug-fix-checklist.md` when the bug spans more than one layer, is hard to reproduce, involves threading/game loop timing, or changes collision/movement behavior.
