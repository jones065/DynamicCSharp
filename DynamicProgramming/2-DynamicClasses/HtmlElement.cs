using Microsoft.CSharp.RuntimeBinder;
using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Dynamic;
using System.Text;

namespace DynamicProgramming;


public class HtmlElement : DynamicObject, IDictionary<string, object?>
{
    private readonly Dictionary<string, object?> _attributes = new();

    #region DynamicObject overrides
    public override bool TrySetMember(SetMemberBinder binder, object? value)
    {
        try
        {
            if (_attributes.ContainsKey(binder.Name))
            {
                _attributes[binder.Name] = value;
            }
            else
            {
                _attributes.Add(binder.Name, value);
            }
            return true;
        }
        catch
        {
            return false;
        }
    }

    public override bool TryGetMember(GetMemberBinder binder, out object? result)
    {
        return _attributes.TryGetValue(binder.Name, out result);
    }

    public override IEnumerable<string> GetDynamicMemberNames()
    {
        return _attributes.Keys.ToList().AsReadOnly();
    }

    public override bool TryInvokeMember(InvokeMemberBinder binder, object?[]? args, out object? result)
    {
        if(binder.Name is "Render")
        {
            result = this.ToString();
            return true;
        }

        result = null;
        return false;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.Append($"<{TagName}");

        foreach (var attr in _attributes)
        {
            sb.Append($" {attr.Key}=\"{attr.Value}\"");
        }

        sb.Append(">");

        sb.Append(InnerHtml);

        sb.Append($"</{TagName}>");

        return sb.ToString();
    }

    public override bool TryInvoke(InvokeBinder binder, object?[]? args, out object? result)
    {
        result = ToString();
        return true;
    }
    #endregion DynamicObject overrides

    public string TagName { get; set; }

    public ICollection<string> Keys => _attributes.Keys;

    public ICollection<object?> Values => _attributes.Values;

    public int Count => _attributes.Keys.Count;

    public bool IsReadOnly => true;

    public object? this[string key] 
    {
        get => _attributes[key]; 
        set => _attributes[key] = value;
    }

    public HtmlElement(string tagName) => TagName = tagName;

    public string InnerHtml { get; set; } = "";

    public void Add(string key, object? value)
    {
        throw new NotImplementedException();
    }

    public bool ContainsKey(string key)
    {
        throw new NotImplementedException();
    }

    public bool Remove(string key)
    {
        throw new NotImplementedException();
    }

    public bool TryGetValue(string key, [MaybeNullWhen(false)] out object? value)
    {
        throw new NotImplementedException();
    }

    public void Add(KeyValuePair<string, object?> item)
    {
        throw new NotImplementedException();
    }

    public void Clear()
    {
        throw new NotImplementedException();
    }

    public bool Contains(KeyValuePair<string, object?> item)
    {
        throw new NotImplementedException();
    }

    public void CopyTo(KeyValuePair<string, object?>[] array, int arrayIndex)
    {
        throw new NotImplementedException();
    }

    public bool Remove(KeyValuePair<string, object?> item)
    {
        throw new NotImplementedException();
    }

    public IEnumerator<KeyValuePair<string, object?>> GetEnumerator()
    {
        return _attributes.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return _attributes.GetEnumerator();
    }
}
