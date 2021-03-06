using UnityEngine;

public abstract class ISelectable
{
    public bool Selected;
    
    public abstract void OnSelect();
    public abstract void OnDeselect();
}

public class SelectableVertex : ISelectable
{
    private Vertex vertex;

    public SelectableVertex(Vertex vertex)
    {
        this.vertex = vertex;
    }
    
    public override void OnSelect()
    {
        Selected = true;
        vertex.Renderer.SetColor(Color.yellow);

        if (EditorController.Instance.SelectedVertices.Contains(vertex)) { return; }
        EditorController.Instance.SelectedVertices.Add(vertex);
    }

    public override void OnDeselect()
    {
        if (!EditorController.Instance.SelectedVertices.Contains(vertex)) { return; }
        
        Selected = false;
        vertex.Renderer.SetColor(Color.red);
    }
}