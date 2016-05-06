        var i =6;
        $(document)
            .on('click',
                '#close-preview',
                function() {
                    $('.image-preview').popover('hide');
                    // Hover befor close the preview    
                });

        $(function() {
            // Create the close button
            var closebtn = $('<button/>',
            {
                type: "button",
                text: 'x',
                id: 'close-preview',
                style: 'font-size: initial;',
            });
            closebtn.attr("class", "close pull-right");

            // Clear event
            $('.image-preview-clear')
                .click(function() {
                    $('.image-preview').attr("data-content", "").popover('hide');
                    $('.image-preview-filename').val("");
                    $('.image-preview-clear').hide();
                    $('.image-preview-input input:file').val("");
                    $(".image-preview-input-title").text("Browse");
                });
            // Create the preview image
            $(".image-preview-input input:file")
                .change(function() {
                    
                    var file = this.files[0];
                    var reader = new FileReader();
                    // Set preview image into the popover data-content
                    reader.onload = function(e) {
                        $(".image-preview-input-title").text("Change");
                        $(".image-preview-clear").show();
                        $(".image-preview-filename").val(file.name);
                    }
                    reader.readAsDataURL(file);
                });

            $("#saveChanges")
                .click(function () {
                    var fileName = $('input[type=file]').val().split('\\').pop();
                    var title = $("#movieTitle").val();
                    var genre = $("#genre").val();
                    var duration = $("#duration").val();

                    $('#addr' + i)
                        .html("<td class='hidden-xs text-center'>"+i+"</td>" +
                            "<td><a href=/img/posters/"+ fileName + ">" + fileName + "</a></td>" +    //plik musi być zapisany w img/posters
                            "<td>" + title + "</td>" +
                            "<td class='hidden-xs'>"+ genre +"</td>" +
                            "<td>"+ duration +" min.</td>" +
                            "<td align='center'><a class='btn btn-default'><em class='fa fa-eye'></em></a></td>" +
                            "<td align='center'>" +
                            "<a class='btn btn-default'><em class='fa fa-pencil'></em></a>" +
                            "<a id='removeMovie'" + i + " + class='btn btn-danger'><em class='fa fa-trash'></em></a></td>");

                    $('#moviesTable').append('<tr id="addr' + (i + 1) + '"></tr>');
                    i++;
                });

            $(".btn-danger")
                .click(function () {
                    var movieNum = this.id.charAt(this.id.length - 1);
                    $('#movie'+movieNum).remove();
                });

            $("#descriptionPreview1")
                .click(function ()  {
                    $('td', "#descriptionPreview1").each(function () {
                        $(this).html("<td>" + 5 + " min.</td>");
                    })});
            
        });
 

   