using Godot;
using System.Collections.Generic;

public partial class NodeStateMachine : Node
{
	[Export]
	public NodeState InitialNodeState { get; set; }

	private Dictionary<string, NodeState> _nodeStates = new();
	private NodeState _currentNodeState;
	private string _currentNodeStateName;
	private string _parentNodeName;

	public override void _Ready()
	{
		// Get parent node name
		Node parent = GetParent();
		if (parent != null)
		{
			_parentNodeName = parent.Name;
		}

		// Process all child nodes
		foreach (Node child in GetChildren())
		{
			if (child is NodeState nodeState)
			{
				string stateName = nodeState.Name.ToString().ToLower();

				// Check for duplicate state names
				if (_nodeStates.ContainsKey(stateName))
				{
					GD.PrintErr($"[Ready] Duplicate state name detected: {stateName}");
					continue;
				}

				_nodeStates[stateName] = nodeState;

				// Connect signal
				nodeState.Transition += OnStateTransition;
			}
		}

		// Initialize starting state
		if (InitialNodeState != null)
		{
			_currentNodeState = InitialNodeState;
			_currentNodeStateName = _currentNodeState.Name.ToString().ToLower();
			_currentNodeState.OnEnter();
		}
		else
		{
			GD.PrintErr("[Ready] No initial node state assigned!");
		}
	}

	public override void _Process(double delta)
	{
		_currentNodeState?.OnProcess((float)delta);
	}

	public override void _PhysicsProcess(double delta)
	{
		if (_currentNodeState != null)
		{
			_currentNodeState.OnPhysicsProcess((float)delta);
			_currentNodeState.OnNextTransitions();
			//GD.Print($"{_parentNodeName} Current State: {_currentNodeStateName}");
		}
	}

	private void OnStateTransition(string newStateName)
	{
		//GD.Print($"[Transition] Requested transition to: {newStateName}");
		TransitionTo(newStateName);
	}

	private void TransitionTo(string nodeStateName)
	{
		if (nodeStateName == _currentNodeStateName)
			return;

		if (!_nodeStates.TryGetValue(nodeStateName.ToLower(), out var newNodeState))
		{
			//GD.PrintErr($"[Transition] State not found: {nodeStateName}");
			return;
		}

		_currentNodeState?.OnExit();
		newNodeState.OnEnter();

		_currentNodeState = newNodeState;
		_currentNodeStateName = _currentNodeState.Name.ToString().ToLower();

		//GD.Print($"[Transition] Transitioned to: {_currentNodeStateName}");
	}
}
