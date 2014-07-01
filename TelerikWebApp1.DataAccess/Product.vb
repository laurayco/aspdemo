Public Class Product
    Private _iD As Integer
    Public Property ID() As Integer
        Get
            Return _iD
        End Get
        Set(ByVal value As Integer)
            _iD = value
        End Set
    End Property


    Private _productName As String
    Public Property ProductName() As String
        Get
            Return _productName
        End Get
        Set(ByVal value As String)
            _productName = value
        End Set
    End Property


    Private _price As Decimal
    Public Property Price() As Decimal
        Get
            Return _price
        End Get
        Set(ByVal value As Decimal)
            _price = value
        End Set
    End Property
End Class
