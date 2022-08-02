using System;
using System.Collections.Generic;
using System.Text;

public class Node
{
    private String element;
    private Node next, prev;
    public Node(String s, Node n, Node p)
    {
        element = s;
        next = n;
        prev = p;
    }
    public String getElement() { return element; }
    public Node getNext() { return next; }
    public Node getPrev() { return prev; }
    public void setElement(String e) { element = e; }
    public void setNext(Node n) { next = n; }
    public void setPrev(Node n) { prev = n; }

    public void insertFirst(Node list, string newElement)
    {
        Node newNode = new Node(newElement, list, null);
        list.setPrev(newNode);
    }

    public Node insertLast(Node list, string newElement)
    {
        Node newNode = new Node(newElement, null, null);

        if (list.element == null)
        {
            list = newNode;
            newNode.setPrev(null);
        }
        else
        {
            Node aux = list;
            while(aux.getNext() != null)
            {
                aux = aux.getNext();
            }

            aux.setNext(newNode);
            newNode.setPrev(aux);
        }

        return newNode;
    }

    public void insertOrdenate( string newElement)
    {
        Node newNode = new Node(newElement, null, null);

        // Eh o primeiro elemento da lista
        if (this.getNext() == null && this.getPrev() == null)
        {
            this.setElement(newNode.getElement());
            this.setPrev(newNode.getPrev());
            this.setNext(newNode.getNext());
        }

        else if(string.Compare(newNode.getElement(), this.getElement()) < 0)
        {
            newNode.setNext(this);
            this.setPrev(newNode);

            this.setElement(newNode.getElement());
            this.setPrev(newNode.getPrev());
            this.setNext(newNode.getNext());
        }

        else
        {
            Node aux = this;
            while(aux.getNext() != null && string.Compare(newNode.getElement(), aux.getNext().getElement()) > 0)
            {
                aux = aux.getNext();
            }

            newNode.setNext(aux.getNext());
            if(aux.getNext() != null)
            {
                aux.getNext().setPrev(newNode);
            }

            newNode.setPrev(aux);
            aux.setNext(newNode);
        }
    }

    public Node find(string element)
    {
        Node aux, node = new Node(null, null, null);

        aux = this;
        while(aux != null && aux.getElement().ToLower() != element.ToLower())
        {
            aux = aux.getNext();
        }

        if(aux != null && aux.getElement() != null)
        {
            node = aux;
        }

        return node;
    }

    public boolean isFirst() {
        return this.getNext() != null && this.getPrev() != null;
    }
    
    public boolean isLast() {
        return this.getNext() == null;
    }

    public Node getFirst()
    {
        Node aux = this;

        // Se o atual não for o primeiro
        if (!this.isFirst())
        {
            while(aux.getPrev() != null)
            {
                aux = this.getPrev();
            }
        }

        return aux;
    }

    public Node getLast()
    {
        Node aux = this;

        // Se o atual não for o ultimo elemento, busca o ultimo
        if (!aux.isLast())
        {
            while(!aux.isLast())
            {
                aux = this.getNext();
            }
        }

        return aux;
    }

    public void removeFirst()
    {
        Node first = this.getFirst();
        
        // Pega o segundo elemento
        Node second = first.getNext();
        
        // Retira o encadeamento para o primeiro
        second.setPrev(null);

        first.setElement(null);
        first.setPrev(null);
        first.setNext(null);
    }

    public void removeLast()
    {
        Node last = this.getLast();
        
        // Pega o segundo elemento
        Node newLast = last.getPrev();
        
        // Retira o encadeamento para o ultimo
        newLast.setNext(null);

        last.setElement(null);
        last.setPrev(null);
        last.setNext(null);
    }

    public void print()
    {
        Console.WriteLine(this.getElement());

        Node node = this.getNext();
        while(node != null)
        {
            Console.WriteLine(node.getElement());
            node = node.getNext();
        }

        Console.WriteLine("\n\n");
    }

    public int getSize()
    {
        int count = 1;
        Node node = this.getNext();
        while(node != null)
        {
            count++;
        }

        return count;
    }
}