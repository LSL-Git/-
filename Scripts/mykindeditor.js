KindEditor.ready(function (K) {
    var editor = K.create('#content', {
        //上传管理
        uploadJson: '~/kindeditor/asp.net/upload_json.ashx',
        //文件管理
        fileManagerJson: '~/kindeditor/asp.net/file_manager_json.ashx',
        // 是否允许文件管理
        allowFileManager: true,
        //设置编辑器创建后执行的回调函数
        afterCreate: function () {
            var self = this;
            K.ctrl(document, 13, function () {
                self.sync();
                K('form[name=example]')[0].submit();
            });
            K.ctrl(self.edit.doc, 13, function () {
                self.sync();
                K('form[name=example]')[0].submit();
            });
        },
        //上传文件后执行的回调函数,获取上传图片的路径
        afterUpload: function (url) {
            alert(url);
        },
        //编辑器宽度
        width: '100%;',
        // 设置编辑器宽度不可调，如果指为0这宽度，高度都不可调
        resizeType: 1,
        //编辑器高度
        height: '500px;',
        //配置编辑器的工具栏
        items: [
            'source', '|', 'undo', 'redo', '|', 'preview', 'print', 'template', 'code', 'cut', 'copy', 'paste',
            'plainpaste', 'wordpaste', '|', 'justifyleft', 'justifycenter', 'justifyright',
            'justifyfull', 'insertorderedlist', 'insertunorderedlist', 'indent', 'outdent', 'subscript',
            'superscript', 'clearhtml', 'quickformat', 'selectall', '|', 'fullscreen', '/',
            'formatblock', 'fontname', 'fontsize', '|', 'forecolor', 'hilitecolor', 'bold',
            'italic', 'underline', 'strikethrough', 'lineheight', 'removeformat', '|', 'image', 'multiimage',
            'flash', 'media', 'insertfile', 'table', 'hr', 'emoticons', 'baidumap', 'pagebreak',
            'anchor', 'link', 'unlink', '|', 'about'
        ]
    });
    prettyPrint();
});