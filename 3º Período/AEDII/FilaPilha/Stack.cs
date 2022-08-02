public class Stack
{
    private Node _data;
    private int _total;

    public Stack(Node data, int total)
    {
        _data = data;
        _total = total;
    }

    public Stack(Node data)
    {
        _data = data;
        _total = data.getSize();
    }

    public void Push(string value) {

        // O elemento topo será o ultimo inserido
        Node newNode = _data.insertLast(_data, value);

        _head = newNode;

        _total = _total + 1;

    }

    public Node Pop() { 

        Node element = _data.getLast();

        // Desempilhar remove o ultimo elemento inserido
        _data.removeLast();

        _total = _total - 1;

        return element.getElement();

    }

    public void ShowQueue(){

        _data.print();

    }

}