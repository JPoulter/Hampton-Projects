<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class typeOfRegistration
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(typeOfRegistration))
        Me.label_restaurant = New System.Windows.Forms.Label
        Me.label_user = New System.Windows.Forms.Label
        Me.registerRestaurant = New System.Windows.Forms.Button
        Me.registerIndividual = New System.Windows.Forms.Button
        Me.label_MainPrompt = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'label_restaurant
        '
        Me.label_restaurant.BackColor = System.Drawing.Color.Transparent
        Me.label_restaurant.Dock = System.Windows.Forms.DockStyle.Top
        Me.label_restaurant.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label_restaurant.Location = New System.Drawing.Point(0, 0)
        Me.label_restaurant.Name = "label_restaurant"
        Me.label_restaurant.Size = New System.Drawing.Size(288, 68)
        Me.label_restaurant.TabIndex = 2
        Me.label_restaurant.Text = "restaurant prompt"
        Me.label_restaurant.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'label_user
        '
        Me.label_user.BackColor = System.Drawing.Color.Transparent
        Me.label_user.Dock = System.Windows.Forms.DockStyle.Top
        Me.label_user.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label_user.Location = New System.Drawing.Point(0, 0)
        Me.label_user.Name = "label_user"
        Me.label_user.Size = New System.Drawing.Size(288, 68)
        Me.label_user.TabIndex = 3
        Me.label_user.Text = "user prompt"
        Me.label_user.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'registerRestaurant
        '
        Me.registerRestaurant.BackColor = System.Drawing.Color.Red
        Me.registerRestaurant.Cursor = System.Windows.Forms.Cursors.Hand
        Me.registerRestaurant.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.registerRestaurant.FlatAppearance.BorderSize = 2
        Me.registerRestaurant.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSeaGreen
        Me.registerRestaurant.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PaleGreen
        Me.registerRestaurant.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.registerRestaurant.Font = New System.Drawing.Font("Arial Rounded MT Bold", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.registerRestaurant.ForeColor = System.Drawing.Color.Black
        Me.registerRestaurant.Location = New System.Drawing.Point(19, 89)
        Me.registerRestaurant.Name = "registerRestaurant"
        Me.registerRestaurant.Size = New System.Drawing.Size(247, 54)
        Me.registerRestaurant.TabIndex = 4
        Me.registerRestaurant.Text = "register"
        Me.registerRestaurant.UseVisualStyleBackColor = False
        '
        'registerIndividual
        '
        Me.registerIndividual.BackColor = System.Drawing.Color.SteelBlue
        Me.registerIndividual.Cursor = System.Windows.Forms.Cursors.Hand
        Me.registerIndividual.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.registerIndividual.FlatAppearance.BorderSize = 2
        Me.registerIndividual.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumSeaGreen
        Me.registerIndividual.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PaleGreen
        Me.registerIndividual.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.registerIndividual.Font = New System.Drawing.Font("Arial Rounded MT Bold", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.registerIndividual.ForeColor = System.Drawing.Color.Black
        Me.registerIndividual.Location = New System.Drawing.Point(20, 89)
        Me.registerIndividual.Name = "registerIndividual"
        Me.registerIndividual.Size = New System.Drawing.Size(247, 54)
        Me.registerIndividual.TabIndex = 5
        Me.registerIndividual.Text = "register"
        Me.registerIndividual.UseVisualStyleBackColor = False
        '
        'label_MainPrompt
        '
        Me.label_MainPrompt.BackColor = System.Drawing.Color.Transparent
        Me.label_MainPrompt.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label_MainPrompt.ForeColor = System.Drawing.Color.Black
        Me.label_MainPrompt.Location = New System.Drawing.Point(58, 200)
        Me.label_MainPrompt.Name = "label_MainPrompt"
        Me.label_MainPrompt.Size = New System.Drawing.Size(660, 84)
        Me.label_MainPrompt.TabIndex = 6
        Me.label_MainPrompt.Text = "MAIN_PROMPT"
        Me.label_MainPrompt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.label_restaurant)
        Me.Panel1.Controls.Add(Me.registerRestaurant)
        Me.Panel1.Location = New System.Drawing.Point(58, 299)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(290, 160)
        Me.Panel1.TabIndex = 7
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.registerIndividual)
        Me.Panel2.Controls.Add(Me.label_user)
        Me.Panel2.Location = New System.Drawing.Point(444, 300)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(290, 160)
        Me.Panel2.TabIndex = 8
        '
        'typeOfRegistration
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.Start.My.Resources.Resources.full_world_background
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(799, 491)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.label_MainPrompt)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "typeOfRegistration"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Computer Registration"
        Me.TopMost = True
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents label_restaurant As System.Windows.Forms.Label
    Friend WithEvents label_user As System.Windows.Forms.Label
    Friend WithEvents registerRestaurant As System.Windows.Forms.Button
    Friend WithEvents registerIndividual As System.Windows.Forms.Button
    Friend WithEvents label_MainPrompt As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
End Class
