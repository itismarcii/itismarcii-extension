# itismarcii-extension
Extension package that holds helper classes for an easier workflow


# Contains
- Character (wip)
  - MovementHandler
 - Extra
   - DoubleBuffer
   - MathfConstant
   - MeshTable
   - Filo (FirstInLastOut)
- Factory
  - FactoryBase (abstract class)
  - FactoryMono (abstract class derived from MonoBehaviour)
- Manager
  - GameManagerBase (abstract class derived from MonoBehaviour)
  - IGameManagerComponent (interface for GameManagerBase components)
  - IGameManagerComponentType (interface with generic types for GameManagerBase components)
- Pattern
  - CommandBrain (abstract class)
  - CommandBrainType (abstract class with generic types)
  - ICommand (interface for CommandBrain)
  - ICommandType (interface with generic types for CommandBrainType)
  - FlyweightBase (abstract class)
  - FlyweightFactory (class with generic types)
  - Observer (class with generics)
  - IObserver (interface with generics for Observer)
- Setting (wip)
- Skill (wip)
  - SkillBase
  - SkillBlueprintBase
  - SkillInformationBase
  - SkillModifierBase
  - SkillParamBase
- StateMachine
  - StateMachineBase
  - StateBase
  - StateMachineMono (inherits from MonoBehaviour, executes Update, FixedUpdate, OnTrigger(Enter|Stay|Exit), OnCollision(Enter|Stay|Exit))
  - StateMono
 
# Skill extension
Basic Skill class that handles stages of SkillBases. Allows to attach skills generic on each other to perform custom modifiable skills.

  ### Example execution

  - Skill performs -> Skill finishes -> Skill calls Stages -> Skill activates Stages 
    - SkillStage0 -> Skill performs -> ...
    - SkillStage1 -> Skill performs -> ...

*Stages: Stages are SkillBase objects that are hold in an array inside the SkillBase

  
  
  
