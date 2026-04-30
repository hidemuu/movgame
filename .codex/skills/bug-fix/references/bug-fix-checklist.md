# Bug Fix Checklist

Use this checklist selectively. Do not force every item into the final response.

## Reproduction

- Is the failing behavior stated in concrete terms?
- Is the expected behavior clear?
- Is there a direct path to the affected screen, loop, command, or character action?
- Does the bug occur only on player input, only on game-loop updates, or both?

## Gameplay and Domain

- Are player and enemy movement paths both checked?
- Does `GameEngine.GetCollision(...)` handle the same case from both actors' perspectives?
- Are wall, road, player, alien, and bread type codes handled consistently?
- Are life, score, game-over, and stage-clear state updates triggered after the relevant action?
- Does breadcrumb-based behavior in `BreadAlien` or `BreadPlayer` need separate review?

## WPF and Service Flow

- Are bindings, commands, and ViewModel state updates consistent?
- Does `GameServiceBase.Run()` update state in the expected order?
- Are dialogs shown once rather than repeatedly during the game loop?
- Are drawing and bitmap lifecycle changes safe around `IsBuilding`?

## Verification

- Did the closest project build run?
- If WPF build could not run, is the environment reason recorded?
- Are known existing solution or SDK warnings separated from new failures?
- Were temporary directories such as `.dotnet-home/` removed?

## Change Hygiene

- Is the fix narrowly scoped to the bug?
- Are unrelated dirty files left untouched?
- Are generated files excluded?
- Does the final explanation include root cause, fix, and verification?
