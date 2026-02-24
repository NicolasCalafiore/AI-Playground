# FSM-CitySim
![Untitledvideo-MadewithClipchamp2-ezgif com-video-to-gif-converter](https://github.com/user-attachments/assets/66bc11f1-ad33-4c29-9c87-4a61d2c4ea3f)

A Unity city simulation that uses finite state machines to drive autonomous NPC behavior, including daily routines, jobs, and enterable/exitable buildings.

## Project Overview

This project models a living city where units continuously evaluate priorities and transition between behaviors like working, eating, sleeping, socializing, and roaming. The simulation combines FSM-driven activity selection with needs progression, job scheduling, world structure management, and time-speed controls.

## Technical Highlights

- Built an FSM-driven activity system for autonomous unit behavior transitions
- Implemented need-based behavior pressure (`hunger`, `energy`, `social`) with dynamic thresholds
- Added job-role systems (`Police`, `Cook`) with work-hour gating and work-tasks execution
- Implemented enter/exit building interactions for residences and commercial structures
- Added centralized world registration for structure discovery and staffing/housing allocation
- Added simulation time controls (day/hour/minute progression with adjustable speed multipliers)
- Structured the project into modular layers for units, activities, jobs, structures, and utility systems

## Core Systems

- **Needs System:** units accumulate hunger, fatigue, and social demand over time, which drives state transitions
- **Routine and Activity Flow:** units switch across `Idle`, `Eat`, `Sleep`, `Socialize`, and `Working` behaviors based on current conditions
- **Job System:** role-specific logic assigns locations, uniforms, tasks, and working-hour constraints
- **Structure Interaction:** units move to structures, enter/exit buildings, and update occupancy within residential/commercial capacity constraints
- **World Registry:** global structure tracking enables unit assignment for housing and understaffed workplaces
- **Time Simulation:** city time progression affects work schedules and overall behavior pacing

## Core Files

- `Scripts/Unit/Activity System/Core/ActivityManager.cs`: activity selection and FSM transition orchestration
- `Scripts/Unit/Needs/Core/Needs.cs`: need growth, thresholds, and satisfaction updates
- `Scripts/Unit/Jobs/Core/JobBase.cs`: common job logic and work-hour rules
- `Scripts/Core/WorldRegister.cs`: global structure registration and allocation lookups
- `Scripts/Core/UnitManager.cs`: unit spawning and role assignment
- `Scripts/Core/TimeManager.cs`: simulation clock and speed scaling
- `Scripts/Structures/Core/Structure.cs`: shared structure occupancy and entry/exit behavior
- `Scripts/Utility/UnitUtilities.cs`: movement/spawn helpers and nearest-structure queries

## Lessons Learned

- **FSM behavior design:** structuring clear state transitions for scalable autonomous agent routines
- **Component-based architecture:** decomposing AI behavior into focused Unity components to improve maintainability
- **System coordination:** balancing competing needs, schedules, and environment constraints in real time
- **Navigation and interaction logic:** coordinating NavMesh movement with structure entry/exit and occupancy rules
- **Simulation architecture:** organizing core, activity, job, and structure layers into reusable, extensible systems
