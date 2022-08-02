public class Queue
{
    private Node _data;
    private int _total;

    public Queue(Node data, int total)
    {
        _data = data;
        _total = total;
    }

    public Queue(Node data)
    {
        _data = data;
        _total = data.getSize();
    }

    public void Enqueue(string value) {

        _data.insertLast(_data, value);
        _total = _total + 1;

    }

    public string Dequeue() { 
        
        Node element = _data.getFirst();

        _data.removeFirst();

        _total = _total - 1;

        return element.getElement();

    }

    public void ShowQueue(){

        _data.print();

    }

}