# Maintenance

## ʹ������

### ���ɸ��°�

```
mtnc pack
          -d, --dir ��ԴĿ¼�� Ĭ��Ϊ��ǰ����Ŀ¼
          -o, --output ���ɵĸ��°�
          -c, --config ���ɸ��°�ʹ�õ������ļ�
```

### ����

```
mtnc update
          -d, --dir ��Ҫ���µ�Ŀ¼��Ĭ��Ϊ��ǰ����Ŀ¼
          -u, --url ���°�������·��
          -p, --path ���°����ļ�·�� ����ѡ��һ
```

### ж��

ɾ����ǰ����Ŀ¼�µ������ļ�
```
mtnc uninstall
```

## �߼�����

### ����

#### mtnc pack
���ļ��������½ṹ�����ѹ��
```
������_d
��   ����aaa
��   ����bbb
��   ����ccc
������packages.mtncc
������list
������_s0.bat
������_s1.bat
```
���� packages.mtncc �ļ��ǲ���������Ϣ
```
    public class MaintenanceMeta
    {
        public string Version { get; set; } = null!;
        public int VersionNum { get; set; }
        public string? Description { get; set; }
    }
```
- Version �汾��
- VersionNum �汾������
- Description �汾����
- Script �����ű�
   - When ��ʱִ��
   - Type �ű�����
   - Content �ű�����

list�ļ� ������Ҫ���µ��ļ�����list�ļ���Ҫ��ע[�滻*]/[����+][�Ƴ�-]����
_s0.bat,_s1.bat ���ǲ�ͬʱ��ִ�еĽű���˳����1, 0��0��Ȼ�����ִ�У������ڱȽϳ��ã�����һ�㲻��ʹ��1��

#### mtnc update

1. ��ѹ������������ʱĿ¼
2. ����list�ļ������ݻᱻ�滻���Ƴ��ı����ļ�
3. ��_dĿ¼�µ��ļ������滻�����ļ� -ִ��_s1.bat
4. ���ʧ�ܣ���ع�
5. �ɹ���-ִ��_s0.bat
6. ��ɣ�������ʱ�ļ�


## ����ʵ��

- [ ] ���±��ݣ��ع�
- [ ] ����ʱ�����ƵĴ����������Ҫִ�е�����ű�...(����ע���ֹͣӦ���ٸ���...)